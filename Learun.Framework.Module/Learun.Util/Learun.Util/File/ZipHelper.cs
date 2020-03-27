using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Learun.Util
{
    public class ZipHelper
    {
        private volatile static ZipHelper _instance = null;
        private static readonly object lockHelper = new object();

        private static string pathExe = "C:\\Program Files\\WinRAR\\WinRAR.exe";
        private ZipHelper() { }
        /// <summary>
        /// 单例模式， 考虑线程安全，只允许一个线程访问。
        /// </summary>
        public static ZipHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ZipHelper();
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 解压ZIP文件
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="targetDirectory"></param>
        /// <param name="passWord"></param>
        /// <param name="overWrite"></param>
        public static  bool UnZip(HttpPostedFileBase file, string targetDirectory, string passWord, bool overWrite = true)
        {
            try
            {
                if (Directory.Exists(targetDirectory))
                    Directory.CreateDirectory(targetDirectory);

                if (!targetDirectory.EndsWith("\\")) targetDirectory += "\\";
                using (ZipInputStream zipFiles = new ZipInputStream(file.InputStream))
                {
                    zipFiles.Password = passWord;
                    ZipEntry theEntry;
                    while ((theEntry = zipFiles.GetNextEntry()) != null)
                    {
                        string directoryName = string.Empty;
                        string pathToZip = "";
                        pathToZip = theEntry.Name;

                        if (pathToZip != "")
                            directoryName = Path.GetDirectoryName(pathToZip) + "\\";
                        string fileName = Path.GetFileName(pathToZip);
                        Directory.CreateDirectory(targetDirectory + directoryName);

                        if (fileName != "")
                        {
                            if ((File.Exists(targetDirectory + directoryName + fileName) && overWrite) || (!File.Exists(targetDirectory + directoryName + fileName)))
                            {
                                using (FileStream streamWriter = File.Create(targetDirectory + directoryName + fileName))
                                {
                                    int size = 2048;
                                    byte[] data = new byte[2048];
                                    while (true)
                                    {
                                        size = zipFiles.Read(data, 0, data.Length);
                                        if (size > 0)
                                            streamWriter.Write(data, 0, size);
                                        else
                                            break;
                                    }
                                    streamWriter.Close();
                                }
                            }
                        }

                    }
                }
                return false; ;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 某目录压缩成ZIP压缩文件
        /// </summary>
        /// <param name="filesPath"></param>
        /// <param name="zipFilePath"></param>
        public static void CreateZipFile(string filesPath, string zipFilePath)
        {
            if (!Directory.Exists(filesPath))
            {
                Console.WriteLine("Cannot find directory '{0}'", filesPath);
                return;
            }
            try
            {
                string[] filenames = Directory.GetFiles(filesPath);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {

                    s.SetLevel(9); // 压缩级别 0-9
                                   //s.Password = "123"; //Zip压缩文件密码
                    byte[] buffer = new byte[4096]; //缓冲区大小
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);
            }
        }

        /// <summary>
        /// 选中文件压缩成ZIP文件
        /// </summary>
        /// <param name="filenames">文件路径集合</param>
        /// <param name="zipFilePath">压缩后ZIP路径</param>
        /// <returns></returns>
        public bool CreateZipFile(List<string> filenames, string zipFilePath, string OutName)
        {
            if (filenames.Count == 0)
            {
                return false;
            }
            if (!Directory.Exists(zipFilePath))
                Directory.CreateDirectory(zipFilePath);
            var zipFile = $"{OutName}{ DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
            try
            {
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath + zipFile)))
                {
                    s.SetLevel(9); // 压缩级别 0-9
                                   //s.Password = "123"; //Zip压缩文件密码
                    byte[] buffer = new byte[4096]; //缓冲区大小
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



      
         /// <summary>
         /// 使用Gzip方法压缩文件
         /// </summary>
         /// <param name="sourcefilename"></param>
         /// <param name="zipfilename"></param>
         /// <returns></returns>
         public static bool GZipFile(string sourcefilename, string zipfilename)
         {
             bool isSucc = false;
             //拼接压缩命令参数
             string args = string.Format("a -as -r -afzip -ed -ibck -inul -m5 -mt5 -ep1 {0} {1}", zipfilename, sourcefilename);  
           
             //启动压缩进程
             isSucc = ProcessHelper.StartProcess(pathExe, args);
             return isSucc;
         }
 
         /// <summary>
         /// 使用GZIP解压文件的方法
         /// </summary>
         /// <param name="zipfilename"></param>
         /// <param name="unzipfilename"></param>
         /// <returns></returns>       
         public static bool UnGzipFile(string zipfilename, string unzipfilename)
         {
            string WarPath = Config.GetValue("Winrarkey");
              if(!string.IsNullOrEmpty(WarPath))
            {
                pathExe = WarPath;
            }
             bool isSucc = false;
             if (!Directory.Exists(unzipfilename))
             {
                 Directory.CreateDirectory(unzipfilename);
             }
             //拼接解压命令参数
             string args = string.Format("x -ibck -inul -y -mt5 {0} {1}", zipfilename, unzipfilename); 
            
             //启动解压进程
             isSucc = ProcessHelper.StartProcess(pathExe, args);
             return isSucc;
         }
    }
}
