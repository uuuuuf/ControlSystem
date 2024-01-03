using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrlSystem
{
    public partial class LoginForm : Form
    {

        bool on;
        Point pos;
        public LoginForm()
        {
            InitializeComponent();

            MouseDown += (o, e) => { if (e.Button == MouseButtons.Left) { on = true; pos = e.Location; } };
            MouseMove += (o, e) => { if (on) Location = new Point(Location.X + (e.X - pos.X), Location.Y + (e.Y - pos.Y)); };
            MouseUp += (o, e) => { if (e.Button == MouseButtons.Left) { on = false; pos = e.Location; } };

            txtID.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                loginCheck();
            }
            else
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("ID를 입력해주세요.");
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Password를 입력해주세요.");
                }
            }
        }

        public void loginCheck()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=your_server;Database=your_database;Uid=your_uid;Pwd=your_pwd");

                connection.Open();

                string loginId = txtID.Text;
                string loginPwd = txtPassword.Text;

                string selectQuery = "SELECT member_id, member_password FROM tbl_member WHERE member_id=\'" + loginId + "\'";

                MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);

                MySqlDataReader userAccount = selectCommand.ExecuteReader();

                bool loginFlag = false;

                while(userAccount.Read())
                {
                    if(loginId == (string)userAccount["member_id"] && loginPwd == (string)userAccount["member_password"])
                    {
                        loginFlag = true;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다.");
                        break;
                    }
                }

                if(loginFlag)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }

                userAccount.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    loginCheck();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("ID를 입력해주세요.");
                    }
                    else if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Password를 입력해주세요.");
                    }
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    loginCheck();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("ID를 입력해주세요.");
                    }
                    else if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Password를 입력해주세요.");
                    }
                }
            }
        }
    }
}
