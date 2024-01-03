using GMap.NET;
using System;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using CefSharp.WinForms;
using CefSharp;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenCvSharp;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;

namespace ContrlSystem
{
    public partial class MainForm : Form
    {
        bool on;
        System.Drawing.Point pos;

        bool streamingState = false;
        bool recordingState = false;

        private PointLatLng ptLatLng = new PointLatLng();
        private System.Windows.Forms.Timer tmZoom = new System.Windows.Forms.Timer();

        private int zoom = 0;

        private ChromiumWebBrowser browser;
        private Process pythonProcess;

        private TcpClient tcpClient;
        private NetworkStream clientStream;

        private CancellationTokenSource cancellationTokenSource;

        string recordingPath = @"C:\project\output\";

        private TcpClient client;
        private NetworkStream stream;
        private VideoCapture videoCapture;
        private VideoWriter videoWriter;

        private List<Marker> markerList = new List<Marker>();
        private GMapOverlay markersOverlay = new GMapOverlay("markers");

        double clickLatitude = 0;
        double clickLongitude = 0;

        public MainForm()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            /* 폼 이동 */
            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { on = true; pos = e.Location; } };
            MouseMove += (o, e) => { if (on) Location = new System.Drawing.Point(Location.X + (e.X - pos.X), Location.Y + (e.Y - pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { on = false; pos = e.Location; } };

            pnStreamingView.Visible = false;

            /* 지도 관련 변수들 */
            ptLatLng = new PointLatLng(37.5665, 126.9780);  // 지도에서 처음 보여주는 위치
            zoom = 19;
            gMapControl.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            gMapControl.Position = ptLatLng;
            gMapControl.Zoom = zoom;

            tmZoom.Interval = 500;
            tmZoom.Start();

            Controls.Add(gMapControl);

            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            txtLog.AppendText("지도 로드 성공.\r\n");

            socketOpen();
        }

        private void socketOpen()
        {
            try
            {
                tcpClient = new TcpClient("IP Address", PORT);
                clientStream = tcpClient.GetStream();

                cancellationTokenSource = new CancellationTokenSource();

                Task.Run(() => {
                    try
                    {
                        while (!cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            byte[] data = new byte[1024];
                            int bytesRead = clientStream.Read(data, 0, data.Length);

                            if (bytesRead == 0)
                            {
                                break;
                            }

                            string response = Encoding.UTF8.GetString(data, 0, bytesRead);

                            string[] location = response.Split(',');

                            //for(int i = 0; i < location.Length; i++)
                            //{
                            //    Console.WriteLine("구분자[" + i + "]: " + location[i]);
                            //}

                            if (location[0].Equals("CurLocation"))
                            {
                                string vID = location[1];
                                double lat = (Double.Parse(location[2]));
                                double lon = (Double.Parse(location[3]));
                                double alt = (Double.Parse(location[4]));

                                txtInfoLatitude.BeginInvoke((MethodInvoker)delegate
                                {
                                    txtInfoLatitude.Clear();
                                    txtInfoLatitude.Text = lat.ToString();
                                });

                                txtInfoLongitude.BeginInvoke((MethodInvoker)delegate
                                {
                                    txtInfoLongitude.Clear();
                                    txtInfoLongitude.Text = lon.ToString();
                                });

                                Console.WriteLine("VehicleID: " + vID + ", lat: " + lat + ", lon: " + lon + ", alt: " + alt);

                                lock (markerList)
                                {
                                    gMapControl.BeginInvoke((MethodInvoker)delegate
                                    {
                                        int removeNum = -1;
                                        for (int i = 0; i < markerList.Count; i++)
                                        {
                                            if (markerList[i].MarkerID == vID)
                                            {
                                                removeNum = i;

                                                break;
                                            }
                                        }

                                        if (removeNum != -1)
                                        {
                                            markersOverlay.Markers.Remove(markerList[removeNum].GMapMarker);
                                            gMapControl.Refresh();
                                            markerList.RemoveAt(removeNum);
                                        }

                                        GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.blue);
                                        Marker marker = new Marker(vID, lat, lon, gMarker);
                                        markerList.Add(marker);
                                        markersOverlay.Markers.Add(gMarker);
                                        gMapControl.Overlays.Add(markersOverlay);
                                        marker.GMapMarker = gMarker;

                                        PointLatLng centerPosition = new PointLatLng(lat, lon);
                                        gMapControl.Position = centerPosition;
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CODE 100: " + ex.Message);
                    }
                    finally
                    {
                        clientStream.Close();
                        tcpClient.Close();
                        txtLog.BeginInvoke((MethodInvoker)delegate
                        {
                            txtLog.AppendText("소켓 연결 끊김.\r\n");
                        });
                    }
                }, cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void closingPython()
        {
            if (pythonProcess != null && !pythonProcess.HasExited)
            {
                pythonProcess.Kill();
                pythonProcess.Dispose();
            }
        }


        private void sendMessage(string message)
        {
            try
            {
                Task.Run(() => {
                    byte[] sendByte = Encoding.UTF8.GetBytes(message);
                    clientStream.Write(sendByte, 0, sendByte.Length);
                    Console.WriteLine($"메세지 전송: {message}");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("CODE 200: " + ex.Message);
            }
        }

        private void openFolderInExplorer(string folderPath)
        {
            txtLog.AppendText("폴더 열기 선택.\r\n");
            try
            {
                Process.Start("explorer.exe", folderPath);

                txtLog.AppendText("폴더 열기 성공.\r\n");
            }
            catch (Exception e)
            {
                MessageBox.Show("CODE 300: 폴더를 열 수 없습니다.\r\n" + e.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtLog.AppendText("폴더 열기 실패.\r\n");
            }
        }

        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void btnMainExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLiveStreaming_Click(object sender, EventArgs e)
        {
            if (streamingState)
            {
                btnRecording.Enabled = true;
                streamingState = false;
                btnLiveStreaming.Text = "실시간 스트리밍 시작";

                pnStreamingView.Visible = false;
                pnStreamingView.SendToBack();

                cancellationTokenSource?.Cancel();

                if (pythonProcess != null && !pythonProcess.HasExited)
                {
                    pythonProcess.Kill();
                    pythonProcess.WaitForExit(); // 종료될 때까지 대기
                }

                Delay(10000);
                socketOpen();
            }
            else
            {
                sendMessage("streaming");
                btnRecording.Enabled = false;
                streamingState = true;
                btnLiveStreaming.Text = "실시간 스트리밍 중지";

                Thread.Sleep(1000);

                string pythonScriptPath = "C:\\project\\python\\streaming_pc.py";

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "python"; // 파이썬 실행 파일 경로 (시스템 환경 변수에 등록되어 있어야 함)
                startInfo.Arguments = pythonScriptPath;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;

                pythonProcess = Process.Start(startInfo);
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            pnStreamingView.Location = new System.Drawing.Point(0, 0);
            pnStreamingView.Size = new System.Drawing.Size(1920, 1080);

            btnExpand.Visible = false;
            btnExpand.SendToBack();

            btnExpandExit.Visible = true;
            btnExpandExit.BringToFront();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientStream != null)
            {
                clientStream.Close();
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
            }

            tmZoom.Stop();
            tmZoom.Dispose();

            gMapControl.Dispose();

            if (videoCapture != null)
            {
                videoCapture.Release();
            }

            if (stream != null)
            {
                stream.Close();
            }

            if (client != null)
            {
                client.Close();
            }

            closingPython();
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng mousePosition = gMapControl.FromLocalToLatLng(e.X, e.Y);
                clickLatitude = mousePosition.Lat;
                clickLongitude = mousePosition.Lng;

                txtMoveLatitude.Text = clickLatitude.ToString();
                txtMoveLongitude.Text = clickLongitude.ToString();
            }
        }

        private void btnExpandExit_Click(object sender, EventArgs e)
        {
            pnStreamingView.Location = new System.Drawing.Point(0, 880);
            pnStreamingView.Size = new System.Drawing.Size(300, 200);

            btnExpandExit.Visible = false;
            btnExpandExit.SendToBack();

            btnExpand.Visible = true;
            btnExpand.BringToFront();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(recordingPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            openFolderInExplorer(recordingPath);
        }

        private void btnRecording_Click(object sender, EventArgs e)
        {
            if (recordingState == false)
            {
                recordingState = true;
                btnRecording.Text = "카메라 녹화 중지";

                // 카메라 녹화 시작
            }
            else
            {
                recordingState = false;
                btnRecording.Text = "카메라 녹화";

                // 카메라 녹화 종료
            }
        }

        private void btnMoveLocation_Click(object sender, EventArgs e)
        {
            if (clickLatitude != 0 && clickLongitude != 0)
            {
                string movingMessge = clickLatitude + "," + clickLongitude;
                sendMessage("moving," + movingMessge);
            }
            else
            {
                MessageBox.Show("이동할 좌표를 지도에서 클릭해주세요.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
