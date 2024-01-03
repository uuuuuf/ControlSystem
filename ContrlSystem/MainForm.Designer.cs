namespace ContrlSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMainExit = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInfoLatitude = new System.Windows.Forms.TextBox();
            this.txtInfoLongitude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoveLatitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoveLongitude = new System.Windows.Forms.TextBox();
            this.btnMoveLocation = new System.Windows.Forms.Button();
            this.btnLiveStreaming = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRecording = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.pnStreamingView = new System.Windows.Forms.Panel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.btnExpandExit = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pnStreamingView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMainExit
            // 
            this.btnMainExit.BackColor = System.Drawing.Color.Red;
            this.btnMainExit.Location = new System.Drawing.Point(1870, 0);
            this.btnMainExit.Name = "btnMainExit";
            this.btnMainExit.Size = new System.Drawing.Size(50, 50);
            this.btnMainExit.TabIndex = 1;
            this.btnMainExit.Click += new System.EventHandler(this.btnMainExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(1500, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 1080);
            this.panel1.TabIndex = 2;
            // 
            // txtInfoLatitude
            // 
            this.txtInfoLatitude.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInfoLatitude.Location = new System.Drawing.Point(1535, 130);
            this.txtInfoLatitude.Name = "txtInfoLatitude";
            this.txtInfoLatitude.Size = new System.Drawing.Size(360, 30);
            this.txtInfoLatitude.TabIndex = 3;
            // 
            // txtInfoLongitude
            // 
            this.txtInfoLongitude.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInfoLongitude.Location = new System.Drawing.Point(1535, 170);
            this.txtInfoLongitude.Name = "txtInfoLongitude";
            this.txtInfoLongitude.Size = new System.Drawing.Size(360, 30);
            this.txtInfoLongitude.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1535, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "위경도 정보";
            // 
            // txtMoveLatitude
            // 
            this.txtMoveLatitude.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoveLatitude.Location = new System.Drawing.Point(1535, 300);
            this.txtMoveLatitude.Name = "txtMoveLatitude";
            this.txtMoveLatitude.Size = new System.Drawing.Size(360, 30);
            this.txtMoveLatitude.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1535, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "이동 위경도";
            // 
            // txtMoveLongitude
            // 
            this.txtMoveLongitude.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoveLongitude.Location = new System.Drawing.Point(1535, 340);
            this.txtMoveLongitude.Name = "txtMoveLongitude";
            this.txtMoveLongitude.Size = new System.Drawing.Size(360, 30);
            this.txtMoveLongitude.TabIndex = 8;
            // 
            // btnMoveLocation
            // 
            this.btnMoveLocation.BackColor = System.Drawing.Color.White;
            this.btnMoveLocation.Location = new System.Drawing.Point(1535, 380);
            this.btnMoveLocation.Name = "btnMoveLocation";
            this.btnMoveLocation.Size = new System.Drawing.Size(360, 34);
            this.btnMoveLocation.TabIndex = 9;
            this.btnMoveLocation.Text = "이동하기";
            this.btnMoveLocation.UseVisualStyleBackColor = false;
            this.btnMoveLocation.Click += new System.EventHandler(this.btnMoveLocation_Click);
            // 
            // btnLiveStreaming
            // 
            this.btnLiveStreaming.BackColor = System.Drawing.Color.White;
            this.btnLiveStreaming.Location = new System.Drawing.Point(1535, 510);
            this.btnLiveStreaming.Name = "btnLiveStreaming";
            this.btnLiveStreaming.Size = new System.Drawing.Size(360, 34);
            this.btnLiveStreaming.TabIndex = 10;
            this.btnLiveStreaming.Text = "실시간 스트리밍 시작";
            this.btnLiveStreaming.UseVisualStyleBackColor = false;
            this.btnLiveStreaming.Click += new System.EventHandler(this.btnLiveStreaming_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1535, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "카메라";
            // 
            // btnRecording
            // 
            this.btnRecording.BackColor = System.Drawing.Color.White;
            this.btnRecording.ForeColor = System.Drawing.Color.Black;
            this.btnRecording.Location = new System.Drawing.Point(1535, 550);
            this.btnRecording.Name = "btnRecording";
            this.btnRecording.Size = new System.Drawing.Size(360, 34);
            this.btnRecording.TabIndex = 12;
            this.btnRecording.Text = "카메라 녹화";
            this.btnRecording.UseVisualStyleBackColor = false;
            this.btnRecording.Click += new System.EventHandler(this.btnRecording_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.BackColor = System.Drawing.Color.White;
            this.btnOpenFolder.Location = new System.Drawing.Point(1535, 590);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(360, 34);
            this.btnOpenFolder.TabIndex = 13;
            this.btnOpenFolder.Text = "녹화 폴더 열기";
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // pnStreamingView
            // 
            this.pnStreamingView.BackColor = System.Drawing.Color.White;
            this.pnStreamingView.Controls.Add(this.btnExpand);
            this.pnStreamingView.Location = new System.Drawing.Point(0, 880);
            this.pnStreamingView.Name = "pnStreamingView";
            this.pnStreamingView.Size = new System.Drawing.Size(300, 200);
            this.pnStreamingView.TabIndex = 14;
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(250, 150);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(50, 50);
            this.btnExpand.TabIndex = 0;
            this.btnExpand.Text = "확대";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // gMapControl
            // 
            this.gMapControl.BackColor = System.Drawing.SystemColors.Control;
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 0);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 24;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1500, 1080);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDown);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // btnExpandExit
            // 
            this.btnExpandExit.BackColor = System.Drawing.Color.Red;
            this.btnExpandExit.Location = new System.Drawing.Point(1870, 0);
            this.btnExpandExit.Name = "btnExpandExit";
            this.btnExpandExit.Size = new System.Drawing.Size(50, 50);
            this.btnExpandExit.TabIndex = 15;
            this.btnExpandExit.Click += new System.EventHandler(this.btnExpandExit_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(1535, 679);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(360, 389);
            this.txtLog.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnExpandExit);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.pnStreamingView);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnRecording);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLiveStreaming);
            this.Controls.Add(this.btnMoveLocation);
            this.Controls.Add(this.txtMoveLongitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMoveLatitude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfoLongitude);
            this.Controls.Add(this.txtInfoLatitude);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMainExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnStreamingView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel btnMainExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtInfoLatitude;
        private System.Windows.Forms.TextBox txtInfoLongitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoveLatitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoveLongitude;
        private System.Windows.Forms.Button btnMoveLocation;
        private System.Windows.Forms.Button btnLiveStreaming;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRecording;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Panel pnStreamingView;
        private System.Windows.Forms.Button btnExpand;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Panel btnExpandExit;
        private System.Windows.Forms.TextBox txtLog;
    }
}

