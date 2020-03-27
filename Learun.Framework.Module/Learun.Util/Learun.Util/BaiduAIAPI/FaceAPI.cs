using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Learun;
using Baidu.Aip.Face;
using System.IO;
using Learun.Util;
using System.Drawing;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


//<add key = "IPAddress" value="218.25.119.146:20003" />
//<add key = "faceclientId" value="rTnUGz4RZyi1gFX5uiQiS6qd" />
//<add key = "faceclientSecret" value="jBA9Yy5FBmh7vMBHLf5b677gYGcfIqob" />
//<add key = "faceliveness" value="0.393241" />
//<add key = "facescore" value="70" />

namespace Learun
{
    public class FaceAPI
    {

        private static string clientId = Config.GetValue("faceclientId");
       // public static String clientId = "rTnUGz4RZyi1gFX5uiQiS6qd";
        // 百度云中开通对应服务应用的 Secret Key
        public static String clientSecret = Config.GetValue("faceclientSecret");
        //"jBA9Yy5FBmh7vMBHLf5b677gYGcfIqob";


        /// <summary>
        /// 人脸库添加
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="sourceImage"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static string UserAdd(string Uid, byte[] sourceImage, string groupId)
        {
            var client = new Face(clientId, clientSecret);
            var options = new Dictionary<string, object>{
	    {"action_type", "replace"}
	};
            var result = client.UserAdd(Uid, "", groupId, sourceImage,options);

            JObject respObj = JsonConvert.DeserializeObject(result.ToString()) as JObject;
            // 服务失败，不抛异常
            if (result["error_code"] != null)
            {
                return "-1";
            }
            else
            {
                return result["log_id"].ToString();
            }
        }

        /// <summary>
        /// 人脸库更新
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="sourceImage"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static string UserUpdate(string Uid, byte[] sourceImage, string groupid)
        {
            var client = new Face(clientId, clientSecret);
            var options = new Dictionary<string, object>{
	    {"action_type", "replace"}
	};
            var result = client.UserUpdate(Uid, "", groupid, sourceImage,options);
            JObject respObj = JsonConvert.DeserializeObject(result.ToString()) as JObject;
            // 服务失败，不抛异常
            if (result["error_code"] != null)
            {
                return "-1";
            }
            else
            {
                return result["log_id"].ToString();
            }

        }

        /// <summary>
        /// 人脸删除
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static string UserDelete(string Uid, string groupid)
        {
            var client = new Face(clientId, clientSecret);
            var options = new Dictionary<string, object>{
        {"group_id", groupid}
    };
            var result = client.UserDelete(Uid, options);
            JObject respObj = JsonConvert.DeserializeObject(result.ToString()) as JObject;
            // 服务失败，不抛异常
            if (result["error_code"] != null)
            {
                return "-1";
            }
            else
            {
                return result["log_id"].ToString();
            }

        }


        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="groupId"></param>
        /// <param name="userTopNum"></param>
        /// <returns></returns>
        public static FaceIdentifyModel UserIdentity(byte[] sourceImage, string groupId, int userTopNum = 1)
        {
            var client = new Face(clientId, clientSecret);
            var options = new Dictionary<string, object>{
               {"user_top_num", userTopNum}
    };
            var result = client.Identify(groupId, sourceImage, options);
            return result.ToObject<FaceIdentifyModel>();

        }


        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="groupId"></param>
        /// <param name="userTopNum"></param>
        /// <returns></returns>
        public static FaceIdentifyModel UserMutliIdentity(byte[] sourceImage, string groupId, int userTopNum = 1)
        {
            var client = new Face(clientId, clientSecret);
            var options = new Dictionary<string, object>{
	    {"ext_fields", "faceliveness"},
	    {"user_top_num", 1}
	};
            var result = client.MultiIdentify(groupId,sourceImage,options);
            return result.ToObject<FaceIdentifyModel>();

        }


    }


}
