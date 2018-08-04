using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KMCCC.Launcher;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace ColorLauncherBox
{

    public static class Program
    {
        public static LauncherCore Core = LauncherCore.Create();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            if (args.Length != 0)
                if (args[0] == "*#15987")
                    App.createKey = true;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitiINI.Initi();
            Application.Run(new Loginfrm ());
        }
    }
    public static class App
    {
        //路径
        public static string Path= Application.StartupPath;
        public static string clPath = Application.StartupPath + "\\ColorLauncher";
        public static string musicPath = clPath + @"\bgm\bgm.mp3";
        public static string setPath = clPath + @"\set";
        public static string mcDataPath = Path + "\\ab";
        public static string profilePath = clPath + "\\pfp";
        //状态类开关
        public static bool video = false;
        public static bool isSingle;
        public static string serverHost = "";
        public static string serverPort = "";
        public static bool loginStat = false;
        //是否注销
        public static bool isLogOut=false ;
        //基础设置
        public static string Username="";
        public static string Password="";
        public static string Maxmemory="";
        public static string  JavaPath="";
        public static bool playMusic=true;

        //版本以及路径设置
        public static bool multiVer = false;
        public static string pathShader = "";
        public static string pathMods = "";
        public static string pathRes = "";
        public static string pathSave = "";
        //生成秘钥
        public static bool createKey=false ;
        //清理不保存
        public static bool ClearSetting = false;

        public static string title = "ColorLauncher" ;
        public const string ProgramVer = "1.0";

        //启动版本
        public static string LaunchVer = "";
        public static string updateVer;
        //链接
        public static string imageNotice = "";
        public static string textnotice = "";
        public static string picnotice = "";
        public static string serverWebLink = "";
        public static string discuzWebLink = "";
        public static string skinWebLink = "";
        public static string joinQQGroupLink = "";

        public static string serverName = "";
        public static void Msgbox(string msg)
        {
            MessageBox.Show(msg,"ColorLauncherBox");
        }
        public static string readTxt(string path)
        {
            if (path != "")
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string line = "";
                string linetmp = "";
                while ((linetmp = sr.ReadLine()) != null)
                {
                    line += linetmp + "\r\n";
                }
                return line;
            }
            else
            {
                return "";
            }
        }
        public static string EncryptWithMD5(string source)
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }
            return strbul.ToString();
        }
        //title,LaunchVer,serverName,serverHost,serverPort
        public static bool ANTICHECK()
        {
            if (File.Exists(clPath + "\\lic\\jsy.lic"))
            {
                string result = readTxt(clPath + "\\lic\\jsy.lic");
                string res = EncryptWithMD5(App.title) + EncryptWithMD5(App.LaunchVer) + EncryptWithMD5(App.serverName)
                    + EncryptWithMD5(App.serverHost) + EncryptWithMD5(App.serverPort);

                //生成秘钥
                if (App.createKey)
                {
                    string reslic = App.clPath + "\\sys\\conn.jsys";
                    FileStream fs = new FileStream(reslic, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.Write(res);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }

                result = result.Trim();
                if (result == res)
                    return true;
                else
                    return false;

            }
            else return false;
        }
    }
    public static class PgLog
    {
        private static string logPathName;
        private static string logName;
        public static void Initi()
        {
            if (!Directory.Exists(App.clPath + "\\log"))
            {
                Directory.CreateDirectory(App.clPath + "\\log");
            }
            logName = DateTime.Now.ToString().Replace("/", "")
                .Replace("\\", "").Replace(":", "").Replace("-", "").Replace(" ", "");
            logPathName = App.clPath + "\\log\\" + logName + ".log";
            print(logName + "  Initi...");
        }

        public static void print(string outText)
        {
            FileStream fs = new FileStream(logPathName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("[" + DateTime.Now + "] " + outText);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }


    public static class InitiINI
    {
        public static void Initi()
        {
            string INIPATH = App.clPath  + "\\sys\\basic.jsys";
            App.title = IniFile.ReadIniData("ini", "title", App.title, INIPATH) + " " + App.ProgramVer;
            App.LaunchVer = IniFile.ReadIniData("ini", "launchver", App.title, INIPATH);
            App.imageNotice = IniFile.ReadIniData("ini", "imagenotice", "http://www.jayshonyves.net",INIPATH);
            App.textnotice = IniFile.ReadIniData("ini", "textnotice", "http://www.jayshonyves.net/ImageNotice/notice.txt", INIPATH);
            App.picnotice = IniFile.ReadIniData("ini", "picnotice", "http://www.jayshonyves.net/ImageNotice/pic.jpg", INIPATH);
            App.serverWebLink = IniFile.ReadIniData("ini", "serverWeb", "", INIPATH);
            App.discuzWebLink  = IniFile.ReadIniData("ini", "discuzWeb", "", INIPATH);
            App.skinWebLink = IniFile.ReadIniData("ini", "skinWeb", "http://www.skinme.cc", INIPATH);
            App.joinQQGroupLink  = IniFile.ReadIniData("ini", "QQGroupWeb", "", INIPATH);
            App.serverName = IniFile.ReadIniData("ini", "servername", "Jayshonyves", INIPATH);
            if (IniFile.ReadIniData("video", "oc", "False", App.setPath + "\\video.ini") == "true")
                App.video  = true;
            string SYSPATH = App.clPath + "\\sys\\client.jsys";
            if (IniFile.ReadIniData("client", "server", "false", SYSPATH) != "true")
                App.isSingle = true;
            else App.isSingle = false;
            App.serverHost = IniFile.ReadIniData("client", "host", "false", SYSPATH);
            App.serverPort = IniFile.ReadIniData("client", "port", "false", SYSPATH);

            #region DebugPrint
            PgLog.Initi();
            PgLog.print("CLPath:" + App.clPath);
            PgLog.print("INIPATH:" + INIPATH);
            PgLog.print("title:" + App.title );
            PgLog.print("LaunchVer:"+ App.LaunchVer );
            PgLog.print("imageNotice:"+App.imageNotice );
            PgLog.print("textnotice:"+App.textnotice );
            PgLog.print("picnotice:"+App.picnotice );
            PgLog.print("serverWebLink:"+App.serverWebLink );
            PgLog.print("discuzWebLink:"+App.discuzWebLink );
            PgLog.print("skinWebLink:"+App.skinWebLink) ;
            PgLog.print("joinQQGroupLink:"+App.joinQQGroupLink );
            PgLog.print("serverName:"+App.serverName );
            PgLog.print("serverHost:"+App.serverHost );
            PgLog.print("serverPort:" + App.serverPort);
            PgLog.print("ProgramVer:" + App.ProgramVer);
            PgLog.print("profilePath:" + App.profilePath);
            PgLog.print("Video:" + App.video.ToString());
            PgLog.print("isSingle:"+App.isSingle.ToString());
            #endregion

            if (!App.ANTICHECK())
            { MessageBox.Show("配置失败");Application.Exit(); }
        }
    }


}
