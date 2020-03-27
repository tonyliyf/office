using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Learun.Application.Base.SystemModule;
using Learun.Util;

namespace Learun.Application.WebApi
{
    public class UrlRepalceUtil
    {
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();

        //替换路径 
        public  string ReplaceUrl(string Url)
        {
            string systemUrl = Config.GetValue("systemUrl");
            string ServerUrl = Config.GetValue("ServerUrl");

            return Url.Replace(ServerUrl, systemUrl);

        }

        public   string GetUrl(string F_FolderId)
        {
            if(String.IsNullOrEmpty(F_FolderId))
            {
                return string.Empty;
            }
            string temp = string.Empty;
            var data = annexesFileIBLL.GetList(F_FolderId);
            int i = 0;
            foreach(var item in data)
            {
                temp += ReplaceUrl(item.F_FilePath);
                temp += ",";
                i++;
            }
            if(i>0)
            {
                return temp.Substring(0, temp.Length - 1);
            }
            else
            {
                return temp;
            }

        }
    }
}