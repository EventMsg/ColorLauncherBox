using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ColorLauncherBox
{
    class LTools
    {
    }
    public class MP3Player
    {
        /// <summary>   
        /// 文件地址   
        /// </summary>   
        public string FilePath;

        /// <summary>   
        /// 播放   
        /// </summary>   
        public void Play()
        {
            mciSendString("close all", "", 0, 0);
            mciSendString("open " + FilePath + " alias media", "", 0, 0);
            mciSendString("play media", "", 0, 0);
            mciSendString("setaudio media volume to " + volume, null, 0, 0);
        }
        public string volume;
        /// <summary>   
        /// 暂停   
        /// </summary>   
        public void Pause()
        {
            mciSendString("pause media", "", 0, 0);
        }

        /// <summary>   
        /// 停止   
        /// </summary>   
        public void Stop()
        {
            mciSendString("close media", "", 0, 0);
        }

        /// <summary>   
        /// API函数   
        /// </summary>   
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        private static extern int mciSendString(
         string lpstrCommand,
         string lpstrReturnString,
         int uReturnLength,
         int hwndCallback
        );

    }

    public static class IniFile
    {
        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return  temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {

                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }

        #endregion
    }
}
