using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
namespace Learun.WorkFlow.Plugin
{
    public class LogWrite
    {
        /*******************************************************************************************                                                
         * 实例化对象，LogWrite为程序名；                                                
         * private LogWrite lg = new LogWrite("[类名]");                                                
         * 得到程序所在的路径                                                
         LogWrite.serPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase; ;                                                
         写日志                                                
         info.WriteDebugLog(methodName,ex.ToString());                                                 
        ********************************************************************************************/

        public static string serPath;   //日志文件路径,事先指定                                                
        private string className;       //出错的类名                                                

        public LogWrite(string className)
        {
            this.className = className;

            //获取网站在服务器的物理位置                                                
            serPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //                                        
            // TODO: 在此处添加构造函数逻辑                                        
            //                                        
        }

        #region "写日志"                                                
        /// <summary>                                                
        /// 写日志                                                
        /// </summary>                                                
        /// <param name="methodName">方法名称</param>                                                
        /// <param name="errorInfo">错误信息</param>                                                
        public void WriteDebugLog(string methodName, string errorInfo)
        {
            try
            {
                ///指定日志文件的目录                                                
                string fname = serPath + "\\LogInfo.txt";

                ///定义文件信息对象                                                
                FileInfo finfo = new FileInfo(fname);

                ///判断文件是否存在以及是否大于512K                                                
                if (finfo.Exists && finfo.Length > 100 * 1024 * 1024)
                {
                    ///删除该文件                                                
                    finfo.Delete();
                }

                ///创建只写文件流                                                
                using (FileStream fs = finfo.OpenWrite())
                {
                    ///根据上面创建的文件流创建写数据流                                                
                    StreamWriter w = new StreamWriter(fs);

                    ///设置写数据流的起始位置为文件流的末尾                                                
                    w.BaseStream.Seek(0, SeekOrigin.End);

                    w.Write("<------------------------------------------------------------------------------------->\r\n");

                    ///写入“Debug Info: ”                                                
                    w.Write("Debug时间　　：");

                    ///写入当前系统时间                                                
                    w.Write("{0} {1}\r\n", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

                    //写入出错的类名称                                                
                    w.Write("Debug类名　　：" + className + "\r\n");

                    //写入出错的方法名称                                                
                    w.Write("Debug方法名　：" + methodName + "\r\n");

                    //写入错误信息                                                
                    w.Write("Debug错误信息：" + errorInfo + "\r\n");

                    w.Write("<------------------------------------------------------------------------------------->\r\n");

                    ///清空缓冲区内容，并把缓冲区内容写入基础流                                                
                    w.Flush();

                    ///关闭写数据流                                                
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                string strEx = ex.ToString();
            }
        }
        #endregion
    }
}
