using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CCWin;
using System.Net;
using System.Drawing.Text;
using System.Reflection;
using Microsoft.Win32;
using KMCCC.Launcher;
using KMCCC.Authentication;


namespace ColorLauncherBox
{
    public partial class mainFrm : Skin_DevExpress

    {
        public mainFrm()
        {
            PgLog.print("mainFrmInitializeComponent");
            InitializeComponent();
            
            this.Size = new Size(950, 570);
        }

        MP3Player music = new MP3Player();
        
        private void mainFrm_Load(object sender, EventArgs e)
        {
            PgLog.print("mainFrm_Load");
            if (App.discuzWebLink == "") Tdisc.Enabled = false;
            if (App.serverWebLink == "") Tweb.Enabled = false;
            //设置注销按钮

            PgLog.print("AnimeIniti");
            //初始化
            this.Text = App.title;
            pannelIniti();
            panelDis(1);
            InitiProfile();
            Dimpay.Text = App.readTxt(App.clPath + @"\pay\pay.txt");

            helpBox.Text = App.readTxt(App.clPath + @"\help\help.txt");
            //skinRollingBar1.StartRolling ();

            if (App.updateVer != null)
                verL.Text = App.updateVer;

            PgLog.print("LoadPositionAndSize");
            //读取X和Y
            if (File.Exists(App.setPath + "\\size.ini"))
            {
                GameSizeXTxt.Text = IniFile.ReadIniData("size", "X", "", App.setPath + "\\size.ini");
                GameSizeYTxt.Text = IniFile.ReadIniData("size", "Y", "", App.setPath + "\\size.ini");
            }
            PgLog.print("LoadMaxMemoryAndJavaPath");
            //读取最大内存和Java路径的设置
            string setIniPath = App.setPath + "\\set.ini";
            if (File.Exists(setIniPath))
            {
                App.Maxmemory = IniFile.ReadIniData("setting", "maxmemory", "1024", setIniPath);
                App.JavaPath = IniFile.ReadIniData("setting", "javapath", "", setIniPath);
            }

            PgLog.print("LoadProfileImage");
            //读取头像
            if (File.Exists(App.setPath + "\\profile.ini"))
            {
                string pfpPath=IniFile.ReadIniData ("profile","path","", App.setPath + "\\profile.ini");
                if (File.Exists(pfpPath))
                {
                    ProfilePic.Image = Image.FromFile(pfpPath);
                }
                else
                    ProfilePic.Image = Image.FromFile(App.clPath + "\\pfp\\defualt.jpg");

            }
            else ProfilePic.Image = Image.FromFile(App.clPath + "\\pfp\\defualt.jpg");

            PgLog.print("LoadvarText");
            //读取变量到输入框
            DisUsername.Text = App.Username;
            UsernameTxt.Text = App.Username;
            if (App.Maxmemory == "")
                App.Maxmemory = "1024";
            MaxMemoryTxt.Text = App.Maxmemory;

            if(App.JavaPath =="")
            {
                try
                {
                    App.JavaPath = KMCCC.Tools.SystemTools.FindJava().First();
                }
                catch
                {
                    MessageBox.Show("没有检测到Java");
                }
            }
            JavaPathTxt.Text = App.JavaPath;

            PgLog.print("MusicIniti");
            //初始化音乐
            if (File.Exists(App.musicPath))
            {
                music.volume = "400";
                music.FilePath = "\"" + App.musicPath + "\"";

                if (App.playMusic)
                {
                    PgLog.print("MusicPlay");
                    music.Play();
                    Tmusic.Tag = "1";
                }
                else
                {
                    Tmusic.Tag = "0";
                }

            }
            else Tmusic.Enabled = false;



        }

        
        //初始化头像
        private void InitiProfile()
        {
            PgLog.print("InitiProfileImage");
            PictureBox[] pb;
            pb = new PictureBox[5];
            pb[0] = pp1;
            pb[1] = pp2;
            pb[2] = pp3;
            pb[3] = pp4;
            pb[4] = pp5;
            
            for(int i = 0; i < pb.Length; i++)
            {
                pb[i].Click += CProfile_Click;
                pb[i].Tag = App.clPath + "\\pfp\\" + i + ".jpg";
                pb[i].Image = Image.FromFile(App.clPath + "\\pfp\\" + i + ".jpg");
            }
        }
        private void CProfile_Click(object sender, EventArgs e)
        {
            PictureBox ptb = (PictureBox)sender;
            ProfilePic.Tag = ptb.Tag;
            IniFile.WriteIniData("profile", "path", ptb.Tag.ToString() , App.setPath + "\\profile.ini");
            ProfilePic.Image = ptb.Image;
        }

        //读取TXT


        Point pnp = new Point(951, 37);
        private void panelDis(int index=1)
        {
            PannelAnime.Enabled = false;
            for (int i = 0; i < pn.Length; i++)
            {
                pn[i].Visible = false;
                pn[i].Location = pnp;
            }
            selectPanelIndex = index-1;
            pn[index - 1].Visible = true;
            PannelAnime.Enabled = true;
        }
        public int selectPanelIndex;
        private Panel[] pn = new Panel[6];
        public int panelTargetX = 206;
        private void pannelIniti()
        {
            pn[0] = panel1;
            pn[1] = panel2;
            pn[2] = panel3;
            pn[3] = panel4;
            pn[4] = panel5;
            pn[5] = panel6;
        }
        private void PannelAnime_Tick(object sender, EventArgs e)
        {
            if(Math.Abs(pn[selectPanelIndex].Left - panelTargetX ) > 2)
            {
                pn[selectPanelIndex].Left = pn[selectPanelIndex].Left - (pn[selectPanelIndex].Left - panelTargetX)/8;

            }else
            {
                pn[selectPanelIndex].Left = panelTargetX;
            }
            if(pn[selectPanelIndex].Left==panelTargetX)
            {
                PannelAnime.Enabled = false;
            }
        }

        #region 按钮
        Color c37 = Color.FromArgb(37, 37, 37);
        private void menubtn()
        {
            MenuBtn1.BackColor = c37;
            MenuBtn2.BackColor = c37;
            MenuBtn3.BackColor = c37;
            MenuBtn4.BackColor = c37;
            MenuBtn5.BackColor = c37;
        }
        Color c28 = Color.FromArgb(28, 28, 28);
        private void MenuBtn1_Click(object sender, EventArgs e)
        {
            menubtn();
            MenuBtn1.BackColor = c28;
            panelDis(1);
        }

        private void MenuBtn2_Click(object sender, EventArgs e)
        {
            menubtn();
            MenuBtn2.BackColor = c28;
            panelDis(2);
        }

        private void MenuBtn3_Click(object sender, EventArgs e)
        {
            menubtn();
            MenuBtn3.BackColor = c28;
            panelDis(3);
        }

        private void MenuBtn4_Click(object sender, EventArgs e)
        {
            menubtn();
            MenuBtn4.BackColor = c28;
            panelDis(4);
        }

        private void MenuBtn5_Click(object sender, EventArgs e)
        {
            menubtn();
            MenuBtn5.BackColor = c28;
            panelDis(5);
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void mainFrm_Shown(object sender, EventArgs e)
        {

        }

        private delegate void getWebImage();
        private void Getwebimage()
        {
            if (App.picnotice != "")
            {
                Image _image = Image.FromStream(WebRequest.Create(App.picnotice).GetResponse().GetResponseStream());
                NoticePic.Image = _image;
            }
            
        }
        private void NoticePicTimer_Tick(object sender, EventArgs e)
        {
           try { 
                if(File.Exists (App.setPath + "\\pic.jpg"))
                {
                    NoticePic.Image = Image.FromFile(App.setPath + "\\pic.jpg");
                }else
                {
                    getWebImage dgwi = new getWebImage(Getwebimage);
                    dgwi.BeginInvoke(null, null);
                }
           
            

            webBrowser1.Navigate(App.imageNotice);
            refreshNotice.Enabled = true;
            var request = WebRequest.Create(App.textnotice);

            request.Method = "GET";
            var response = request.GetResponse();
            
            using (var stream = new System.IO.StreamReader(response.GetResponseStream(),Encoding.Default ))
            {
                NoticeL1.Text = stream.ReadLine();
                NoticeL2.Text = stream.ReadLine();
                NoticeL3.Text = stream.ReadLine();
                NoticeL4.Text = stream.ReadLine();
                NoticeL5.Text = stream.ReadLine();
            }

            NoticePicTimer.Enabled = false;
            }
            catch(Exception)
            {
            }
        }


        private void ShowHidePanel_Click(object sender, EventArgs e)
        {
            HidePanel.Visible = true;
        }
        //设置默认分辨率
        private void GameDftBtn_Click(object sender, EventArgs e)
        {
            GameSizeXTxt.Text = "";
            GameSizeYTxt.Text = "";
        }
        //720
        private void Game720Btn_Click(object sender, EventArgs e)
        {
            GameSizeXTxt.Text = "1280";
            GameSizeYTxt.Text = "720";
        }

        private void AutoJavaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                JavaPathTxt.Text = KMCCC.Tools.SystemTools.FindJava().First();
            }catch
            {
                MessageBox.Show("没有检测到Java");
            }
        }

        private void AutoMemoryBtn_Click(object sender, EventArgs e)
        {
            MaxMemoryTxt.Text = (KMCCC.Tools.SystemTools.GetRunmemory() / 2).ToString();
        }

        private void SchJavaBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "javaw.exe";
            openFileDialog1.Filter = "exe files(javaw.exe)|*.exe";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog1.FileName != null)
                {
                    JavaPathTxt.Text = openFileDialog1.FileName;
                }
            }
        }

        private void refreshNotice_Tick(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            refreshNotice.Enabled = false;
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {
            DisUsername.Text = UsernameTxt.Text;
        }

        private void Tmusic_Click(object sender, EventArgs e)
        {
            if(Tmusic.Tag == "1")
            {
                Tmusic.Tag = "0";
                music.Stop();
                App.playMusic = false;
            }else
            {
                Tmusic.Tag = "1";
                music.Play();
                App.playMusic = true;
            }
        }

        private void mainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!App.ClearSetting)
            {
                //储存音乐设置
                if(App.playMusic)
                    IniFile.WriteIniData("music", "OC", "true", App.setPath + "\\musicOC.ini");
                else
                    IniFile.WriteIniData("music", "OC", "false", App.setPath + "\\musicOC.ini");

                //储存基础设置
                IniFile.WriteIniData("setting", "maxmemory", MaxMemoryTxt.Text, App.setPath + "\\set.ini");
                IniFile.WriteIniData("setting", "javapath", JavaPathTxt.Text, App.setPath + "\\set.ini");

                //储存游戏玩家名字
                IniFile.WriteIniData("username", "name", App.Username, App.setPath + "\\username.ini");

                //储存游戏窗口大小设置
                IniFile.WriteIniData("size", "X", GameSizeXTxt.Text, App.setPath + "\\size.ini");
                IniFile.WriteIniData("size", "Y", GameSizeYTxt.Text, App.setPath + "\\size.ini");

            }
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTxt.Text == "" || MaxMemoryTxt.Text == "" || JavaPathTxt.Text == "") 
            {
                MessageBox.Show(this, "请填写完整的设置", "错误提示");
                return;
            }

            PgLog.print("GameStart");

            var core = LauncherCore.Create();
            //MessageBox.Show(core.GameRootPath);
            var Launchversion = core.GetVersion(App.LaunchVer);
            core.JavaPath = JavaPathTxt.Text;
            ushort X, Y;
            if (GameSizeXTxt.Text!= "" && GameSizeYTxt.Text != "")
            {
                X = ushort.Parse(GameSizeXTxt.Text);
                Y = ushort.Parse(GameSizeYTxt.Text);
            }
            else
            {
                X = 1100;
                Y = 510;
            }
            var result = core.Launch(new LaunchOptions
            {
                Version = Launchversion, //Ver为Versions里你要启动的版本名字
                MaxMemory = int.Parse( MaxMemoryTxt.Text) , //最大内存，int类型
                Authenticator = new OfflineAuthenticator(UsernameTxt.Text), //离线启动，ZhaiSoul那儿为你要设置的游戏名
                                                           //Authenticator = new YggdrasilLogin("邮箱", "密码", true), // 正版启动，最后一个为是否twitch登录
                //启动模式，这个我会在后面解释有哪几种
                //Server = new ServerInfo { Address = "服务器IP地址", Port = "服务器端口" },
               
                Size = new WindowSize { Height = Y, Width =X } //设置窗口大小，可以不要
            });
            
            if (result.Success)
            {

                this.Close();
            }else
            {
                MessageBox.Show(result.ErrorMessage);
            }

        }
        private void gameExit()
        {

        }
        private void SchHelpBtn_Click(object sender, EventArgs e)
        {
            int itmp = helpBox.Find(SchFAQBox.Text);
            itmp = itmp < 0 ? 0 : itmp;
            helpBox.Select(itmp, SchFAQBox.TextLength);
            helpBox.Focus();
        }

        private void Tout_Click(object sender, EventArgs e)
        {
                App.isLogOut = true;
            music.Stop();
                this.Close();
        }


        #region 功能按钮
        private void G1_1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.java.com");
        }

        private void G1_2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://pan.baidu.com/s/1fCq8YCwHhPX8kNVZlO2cjQ");
            MessageBox.Show("密码:jkbb");
        }

        private void G2_1_Click(object sender, EventArgs e)
        {
            if(App.serverWebLink!="")
                System.Diagnostics.Process.Start(App.serverWebLink);
            else MessageBox.Show("缺少组件无法使用");
        }

        private void G2_2_Click(object sender, EventArgs e)
        {
            if (App.discuzWebLink != "")
                System.Diagnostics.Process.Start(App.discuzWebLink);
            else MessageBox.Show("缺少组件无法使用");
        }

        private void G2_3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.skinWebLink);
        }

        private void G2_4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.joinQQGroupLink);
        }
        

        private void G3_1_Click(object sender, EventArgs e)
        {
            if (File.Exists(App.Path + "\\ColorModsManager.exe"))
            {
                System.Diagnostics.Process.Start(App.Path + "\\ColorModsManager.exe");
            }
            else MessageBox.Show("缺少组件无法使用");
        }

        private void G3_2_Click(object sender, EventArgs e)
        {
            if (File.Exists(App.Path + "\\ColorRepair.exe"))
            {
                System.Diagnostics.Process.Start(App.Path + "\\ColorRepair.exe");
            }
            else MessageBox.Show("缺少组件无法使用");
        }

        private void G3_3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd");
        }

        private void G3_4_Click(object sender, EventArgs e)
        {
            if (File.Exists(App.Path + "\\hmclcore.exe"))
            {
                System.Diagnostics.Process.Start(App.Path + "\\hmclcore.exe");
            }
            else MessageBox.Show("缺少组件无法使用");
        }
        
        private void G4_1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.Path + "\\");
        }

        private void G4_2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(App.mcDataPath + "\\shaderpacks"))
            {
                System.Diagnostics.Process.Start(App.mcDataPath + "\\shaderpacks");
            }
            else MessageBox.Show("缺少组件无法使用");

        }

        private void G4_3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(App.mcDataPath + "\\resourcepacks"))
            {
                System.Diagnostics.Process.Start(App.mcDataPath + "\\resourcepacks");
            }
            else MessageBox.Show("缺少组件无法使用");

        }

        private void G4_4_Click(object sender, EventArgs e)
        {
            if(Directory.Exists (App.mcDataPath + "\\saves"))
            {
                System.Diagnostics.Process.Start(App.mcDataPath + "\\saves");
            }
            else MessageBox.Show("缺少组件无法使用");

        }
        private void G1_3_Click(object sender, EventArgs e)
        {
            string cljni = Path.GetFullPath("..") + "\\colorlogin.jni";
            if (File.Exists(cljni)) DeleteFile(cljni);
            if (File.Exists(App.setPath + "\\size.ini")) DeleteFile(App.setPath + "\\size.ini");
            if (File.Exists(App.setPath + "\\set.ini")) DeleteFile(App.setPath + "\\set.ini");
            if (File.Exists(App.setPath + "\\userlist.txt")) DeleteFile(App.setPath + "\\userlist.txt");
            if (Directory.Exists(App.clPath + "\\log")) DeleteFile(App.clPath + "\\log");
            App.ClearSetting = true;
            MessageBox.Show("已清理完成");
            Application.Exit();
        }
        #endregion

        private void ProfilePic_Click(object sender, EventArgs e)
        {
            panelDis(6);
        }



        public void DeleteFile(string path)
        {
            try { 
                FileAttributes attr = File.GetAttributes(path);
                if (attr == FileAttributes.Directory)
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    File.Delete(path);
                }
            }catch
            {

            }
        }

        #region 顶部按钮
        private void Tweb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.serverWebLink);
        }

        private void Tdisc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.discuzWebLink);
        }

        private void Tskin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.skinWebLink);
        }
        #endregion

        private void CustomProfileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "*.jpg";
            openFileDialog1.Filter = "JPEG图像文件(*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    ProfilePic.Image = Image.FromFile(openFileDialog1.FileName);
                    ProfilePic.Tag = openFileDialog1.FileName;
                    IniFile.WriteIniData("profile", "path", ProfilePic.Tag.ToString(), App.setPath + "\\profile.ini");
                }
            }
        }

        private void BaiduBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com/s?wd=" + SchBaiduTxt.Text);
        }

        private void MoreHelpBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(App.clPath + "\\help");
        }

        private void G5_1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new ColorLauncherBox.AboutBox1();
            ab.ShowDialog();
        }
    }
}
