using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Learun.Util.Gaode
{
    public  class GaodeUtil
    {

        public static string Gaodeurl = "http://restapi.amap.com/v3/geocode/geo?key=f73d50800f65d1aa1533a45ab869a6ac&s=rsv3&city=湖北省枝江市&address={0}";



        /// <summary>
        /// 高德地图解析函数
        /// </summary>
        /// <param name="strResult">返回结果</param>
        public static string GaoDeAnalysis(string parameters, out double x, out double y)
        {
            string strResult = "";
            string url = string.Format(Gaodeurl, parameters);
            // private static Pattern pattern = Pattern.compile("\"location\":\"(\\d+\\.\\d+),(\\d+\\.\\d+)\"");
            Regex reg = new Regex("\"location\":\"(\\d+\\.\\d+),(\\d+\\.\\d+)\"");
            double[] gps = new double[2];
            try
            {
                HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
                req.ContentType = "multipart/form-data";
                req.Accept = "*/*";
                //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
                req.UserAgent = "";
                req.Timeout = 30000;//30秒连接不成功就中断 
                req.Method = "GET";
                req.KeepAlive = true;

                HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {

                    strResult = sr.ReadToEnd();
                    Match match = reg.Match(strResult);
                    gps[0] = double.Parse(match.Groups[1].ToString());
                    gps[1] = double.Parse(match.Groups[2].ToString());
                    string json = JsonConvert.SerializeObject(strResult);
                                       
                }
            }
            catch (Exception ex)
            {
                strResult = "";
            }
            x = gps[0];
            y = gps[1];
            return strResult;
        }
    }
}
