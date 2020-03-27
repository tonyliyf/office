using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.Encrypt
{
    public class RegisterHelp
    {
        /// <summary>
        /// 判断启动项目录是否存在
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static bool RegeditDirIsExist(string dirName)
        {
            RegistryKey key;
            RegistryKey subkey;
            key = Registry.LocalMachine;
            string fullDir = "software\\microsoft\\windows\\currentVersion\\";
            subkey = key.OpenSubKey(fullDir, true);
            foreach (string keys in subkey.GetSubKeyNames())
            {
                if (keys.ToLower() == dirName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 写键值
        /// </summary>
        public static bool WriteRegName(string systemname, DateTime dt)
        {
            try
            {
                string DirectoryName = Directory.GetCurrentDirectory();  //获取当前目录

                string regName = systemname;             //加入启动项里的节点名

                RegistryKey key;
                RegistryKey subkey;
                RegistryKey mainkey;
                string fullDir = "software\\microsoft\\windows\\currentVersion\\";
                string dir = "run";             ///注册表目录       
                string filePath = DirectoryName + "\\" + regName;    //此处注意是系统程序(如：xp下的C:\windows\system32)的话，直接写文件名即可,否则要完整的路径
                key = Registry.LocalMachine;          //初始化subkey，操作HKEY_LOCAL_MACHINE\software\microsoft\windows\currentVersion\子项        
                subkey = key.OpenSubKey(fullDir, true);

                //目录不存在则创建该目录
                if (!RegeditDirIsExist(dir))
                {
                    subkey.CreateSubKey(dir);
                }
                //以可写的方式打开目录
                mainkey = key.OpenSubKey(fullDir + dir, true);
                if (mainkey.GetValue(regName) == null)
                {
                    mainkey.SetValue(regName, dt);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 根据键查询值
        /// </summary>

        public static DateTime SelectRegName(string systemname)
        {

            DateTime dt = new DateTime(1900, 01, 01);
            RegistryKey key;
            RegistryKey subkey;
            RegistryKey mainkey;
            string fullDir = "software\\microsoft\\windows\\currentVersion\\";
            string dir = "run";             ///注册表目录       
            string regName = systemname;

            key = Registry.LocalMachine;          ///初始化subkey，操作HKEY_LOCAL_MACHINE\software\microsoft\windows\currentVersion\子项        
            subkey = key.OpenSubKey(fullDir, true);
            mainkey = key.OpenSubKey(fullDir + dir, true);
            if (mainkey.GetValue(regName) != null)
            {
                dt = DateTime.Parse((string)mainkey.GetValue(regName));
            }
            return dt;


        }
        /// <summary>
        /// 删除键值
        /// </summary>
        public static bool DeleteRegName(string systemname)
        {

            RegistryKey key;
            RegistryKey subkey;
            RegistryKey mainkey;
            string fullDir = "software\\microsoft\\windows\\currentVersion\\";
            string dir = "run";             ///注册表目录       
            string regName = systemname;

            key = Registry.LocalMachine;          ///初始化subkey，操作HKEY_LOCAL_MACHINE\software\microsoft\windows\currentVersion\子项        
            subkey = key.OpenSubKey(fullDir, true);
            mainkey = key.OpenSubKey(fullDir + dir, true);

            try
            {
                mainkey.DeleteValue(regName);
                return true;
            }
            catch { return false; }
        }
    }
}
