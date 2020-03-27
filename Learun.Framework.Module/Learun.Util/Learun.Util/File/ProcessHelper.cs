using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util
{
    public class ProcessHelper
     {
         /// <summary>
         /// 启动进程执行exe
         /// </summary>
         /// <param name="exePath">exe路径</param>
         /// <param name="exeArgs">exe所需参数</param>
         /// <returns></returns>
         public static bool StartProcess(string exePath, string exeArgs)
         {
             bool isHidden = true;
             bool isSucc = true;
             Process process = new Process();
             process.StartInfo.FileName = exePath;
             process.StartInfo.Arguments = exeArgs;
             if (isHidden)
             {
                 process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                 process.StartInfo.CreateNoWindow = true;              
             }
             else
             {
                 process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                 process.StartInfo.CreateNoWindow = false;
             }         
             process.Start();
             int idx = 1;
             while (!process.HasExited)
             {
                 idx++;
                 process.WaitForExit(1000);
                 if (idx == 50)
                 {
                     process.Kill();
                     isSucc = false;
                 }
             }
             process.Close();
             process.Dispose();                          
             return isSucc;
         }
     }
}
