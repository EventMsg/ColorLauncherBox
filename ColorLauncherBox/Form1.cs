using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ColorLauncherBox
{
    public partial class Loginfrm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public Loginfrm()
        {
            PgLog.print("Load Form1 InitializeComponent");
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PgLog.print("Form1_Load");
            frmIniti();
            PgLog.print("Load title.png");
            LoginTitlePic.Image = Image.FromFile(App.clPath + "\\sys\\title.png");

            LoginTitle.Text = App.serverName;
            //储存密码和自动登录
            bool SavepassCheckb=false ;
            bool autologinCheckb=false ;

            PgLog.print("Load Username");
            //读取用户名
            if (File.Exists(App.setPath + "\\username.ini"))
            {
                App.Username = IniFile.ReadIniData("username", "name", "", App.setPath + "\\username.ini");
            }

            PgLog.print("Load Password");
            //读取保存的密码和自动登录
            string cljni= Path.GetFullPath("..") + "\\colorlogin.jni";
            if (File.Exists(cljni))
            {
                string pw = IniFile.ReadIniData("pw", "pw", "", cljni);
                if (pw == "") {
                    SavepassCheckb = false;
                } else {
                    SavepassCheckb = true;
                    App.Password = pw;
                    PasswordTxt.Text = pw;
                    if (IniFile.ReadIniData("pw", "autologin", "false", cljni) == "True") autologinCheckb = true;
                }
            }

            PgLog.print("Load Versions");
            //读取版本号
            if (File.Exists (App.Path + @"\ColorUpdate\version.ini"))
            {
                string h = "客户端版本：" + App.readTxt(App.Path + @"\ColorUpdate\version.ini");
                verL.Text = h;
                App.updateVer = h;
            }

            PgLog.print("Load Music");
            //读取音乐设置
            string musicIniPath = App.setPath + "\\musicOC.ini";
            if (File.Exists(musicIniPath))
            {
                if (IniFile.ReadIniData("music", "oc", "true", musicIniPath) == "true")
                    App.playMusic = true;
                else
                    App.playMusic = false;
            }
            else
            {
                App.playMusic = true;
                IniFile.WriteIniData("music", "oc", "true", musicIniPath);
            }

            PgLog.print("Load Video");
            //设置视频
            if (App.video )
            {
                this.VedioPlayer.Visible = true;
                VedioPlayer.URL = App.clPath + "\\bgp\\video.mp4";
                VedioPlayer.uiMode = "none";
                VedioPlayer.enableContextMenu = false;
            }

            //xxx
            UsernameTxt.Text = App.Username;

            PgLog.print("Load CheckBtn");
            if (SavepassCheckb)
            {
                SavepassCheck.Checked = true;

                if (!App.isSingle)
                {
                    if (autologinCheckb)
                    {
                        AutoLoginCheck.Checked = true;
                        autologintimer.Enabled = true;
                    }
                }
            }
            if(App.isSingle)
            {
                RegChgBtn.Text = "添加账户";
                L_M1.Text = "选择用户";
                L_M2.Visible = false;
                UsernameTxt.Visible = false;
                PasswordTxt.Visible = false;
                SavepassCheck.Visible = false;
                AutoLoginCheck.Visible = false;
                UserList.Visible = true;
                DelectSelUser.Visible = true;
                if(File.Exists(App.setPath + "\\userlist.txt"))
                {
                    StreamReader sr = new StreamReader(App.setPath + "\\userlist.txt");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        UserList.Items.Add(line);
                    }
                    sr.Close();
                }
                
            }
            else
            {

            }

            /*
            if (App.isSingle)
            {
                this.Hide();
                mainFrm Mainfrm = new mainFrm();
                Mainfrm.ShowDialog();
                Close();
            }*/

        }
        #region 
        private void frmIniti()
        {
            //BackgroundImage = Image.FromFile(App.clPath + "\\bgp\\bg.jpg");
            AutoLoginCheck.Left = PasswordTxt.Left + PasswordTxt.Width - AutoLoginCheck.Width+5;

        }
        #endregion

        private void Loginfrm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Color.FromArgb(60,60,65), 1), 0, 0, this.Width-1, this.Height-1);
        }

        private void Atimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity != 1)
            {
                this.Opacity += 0.05;
            }else
            {
                Atimer.Enabled = false;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            PgLog.print("ClickLoginBtn");
            if (File.Exists(App.clPath + "\\append\\POST.exe"))
                System.Diagnostics.Process.Start(App.clPath + "\\append\\POST.exe");

            PgLog.print("multi");
            if (App.isSingle)
            {
                if (UserList.Items.Count == 0)
                {
                    MessageBox.Show("请添加用户");
                    return;
                }
                else if (UserList.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择用户进行登录");
                    return;
                }else
                {
                    App.Username = UserList.SelectedItem.ToString();
                }

                PgLog.print("SaveUserList");
                FileStream fs = new FileStream(App.setPath + "\\userlist.txt",FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string user in UserList.Items)
                    sw.WriteLine(user);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            else
            {
                if (UsernameTxt.Text == "" || PasswordTxt.Text == "")
                {
                    MessageBox.Show("请填写用户名和密码");
                    return;
                }else
                {
                    PgLog.print("SavePassword");
                    //储存用户密码
                    string cljni = Path.GetFullPath("..") + "\\colorlogin.jni";
                    if (SavepassCheck.Checked)
                        IniFile.WriteIniData("pw", "pw", PasswordTxt.Text, cljni);
                    else IniFile.WriteIniData("pw", "pw", "", cljni);
                    IniFile.WriteIniData("pw", "autologin", AutoLoginCheck.Checked.ToString(), cljni);
                    PgLog.print("SaveUserName");
                    //储存玩家名字
                    App.Username = UsernameTxt.Text;
                    IniFile.WriteIniData("username", "name", App.Username, App.setPath + "\\username.ini");
                }
            }

            PgLog.print("LoadMainFrm");
            //开启窗口等
            autologintimer.Enabled = false;
            mainFrm Mainfrm = new mainFrm();
            PgLog.print("Form1Hide");
            this.Hide();
            VedioPlayer.Ctlcontrols.stop();
            Mainfrm.ShowDialog ();
            if (!App.isLogOut)
            {
                Close();
            }else
            {
                App.isLogOut = false;
                if (!SavepassCheck.Checked) PasswordTxt.Text = "";
                this.Show();
                VedioPlayer.Ctlcontrols.play();
            }
            
        }

        private void Loginfrm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void AutoLoginCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoLoginCheck.Checked)
            {
                SavepassCheck.Checked = true;
            }
            
        }

        private void SavepassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!SavepassCheck.Checked)
            {
                AutoLoginCheck.Checked = false;
            }
        }

        private void autologintimer_Tick(object sender, EventArgs e)
        {
            LoginBtn_Click(null,null);
            autologintimer.Enabled = false;
        }

        private void RegChgBtn_Click(object sender, EventArgs e)
        {
            if(!App.isSingle)
            {
                regFrm regfrm = new regFrm();
                regfrm.ShowDialog();
            }else
            {
                string gt;
                gt= Microsoft.VisualBasic.Interaction.InputBox("请输入添加的用户名,仅支持a-z A-Z 0-9 _","输入");
                if (gt != "")
                {
                    UserList.Items.Add(gt.Trim());
                }
                


            }
            
        }

        private void VedioPlayer_StatusChange(object sender, EventArgs e)
        {
            
        }

        private void DelectSelUser_Click(object sender, EventArgs e)
        {
            if (UserList.Items.Count == 0)
            {
                MessageBox.Show("没有用户");
            } else if (UserList.SelectedIndex == -1)
            {
                MessageBox.Show("请选择用户");
            }else
            {
                UserList.Items.RemoveAt(UserList.SelectedIndex);
                
            }
        }
    }
}
