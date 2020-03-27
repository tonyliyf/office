using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Net.Http;
using Learun.Util;
using System.Text;

namespace Learun.Application.Web.App_Start.Wearver
{
    public class MessageDo
    {
        public void Excute()
        {
            try
            {
                RedisHelper redis = new RedisHelper(0);

                Message mes = new Message();
                mes.lasttime = DateTime.Now;
                mes.msgcontent = "redis测试徐海涛分享";
                mes.msgid = "Eeeeeeeeeeeeee";
                mes.recivesids = "33,29";
                mes.tagretid = "29,33";
                mes.targetname = "徐海涛分享";
                mes.userid = "33";
                // JsonConvert.d
                redis.Set("conversation:itmes29,33", "targetname", "徐海涛分享");
                redis.Set("conversation:itmes29,33", "msgid", "5333eecd04864cfda0022d48a8a025f2");
                redis.Set("conversation:itmes29,33", "recivesids", "33,29");
                redis.Set("conversation:itmes29,33", "targettype", "0");
                redis.Set("conversation:itmes29,33", "lasttime", "1578282405824");
                redis.Set("conversation:itmes29,33", "msgcontent", "redis测试徐海涛分享");
                redis.Set("conversation:itmes29,33", "tagretid", "29,33");
                redis.Set("conversation:itmes29,33", "userid", "33");


                /// redis.Set("conversation:itmes29,30", Newtonsoft.Json.JsonConvert.SerializeObject(mes, Newtonsoft.Json.Formatting.Indented), 20000);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


        public void ExcuteJavaInterface()
        {
            try
            {


                string url = @"http://119.96.166.88:8088//social/PushRemindWebService.jsp?method=pushExternal&title=测试& MsgTitle=测试外部接口";
                url += "&requestdetails=测试外部接口";
                url += "&MsgContent=测试外部接口";
                url += "&requesturl=eeee";
                url += "&receiverIds=j00xht,j00wxy";
                url += "&key=920dfe93-b5ba-4a57-bf4b-8132f056fc6b";
                //   "&requestdetails=" & MsgContent & _
                //"&requesturl=" & LinkUrl & _
                //"&receiverIds=" & Gonghao & _
                //"&key=3d0786ea-13df-44cb-9d23-e0413323ebd5"";  //链接API 地址

                System.Net.HttpWebRequest req = null;
                System.Net.HttpWebResponse res = null;

                req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);  //创建HTTP 请求

                res = (System.Net.HttpWebResponse)req.GetResponse();   //获取请求返回的响应
            }

            catch (Exception ex)
            {

                throw ex;
            }



        }

        public void ExcuteMessageInterface()
        {
           
            try
            {
                using (var client = new HttpClient())
                {

                   
                    client.BaseAddress = new Uri("http://192.168.1.231:89");
                    var content = new FormUrlEncodedContent(new[]
                    {
new KeyValuePair<string, string>("key", "920dfe93-b5ba-4a57-bf4b-8132f056fc6b"),
new KeyValuePair<string, string>("messagetypeid ", "3"),

new KeyValuePair<string, string>("useid","j00xht"),
new KeyValuePair<string, string>("badge ", "1"),
new KeyValuePair<string, string>("msg  ", "督办测试是否能收到自定义推送消息"),
new KeyValuePair<string, string>("module  ", "-2"),
});

                    Para para = new Para();
                    para.messagetypeid = "3";
                    para.module = "-2";
                    para.url = "www.baidu.com";

                    //  para.ToJson();
                    StringBuilder buf = new StringBuilder();
                    buf.Append("j00xht");
                    buf.Append("督办测试是否能收到自定义推送消息");
                    buf.Append("1");

                    buf.Append(para.ToJson());
                    buf.Append("920dfe93-b5ba-4a57-bf4b-8132f056fc6b");

                    byte[] decBytes = System.Text.Encoding.UTF8.GetBytes(buf.ToString());
                    sbyte[] mSByte = new sbyte[decBytes.Length];

                    for (int i = 0; i < decBytes.Length; i++)
                    {
                        mSByte[i] = (sbyte)decBytes[i];
                    }

                    var content2 = new FormUrlEncodedContent(new[]
 {


new KeyValuePair<string, string>("useid","j00xht"),
new KeyValuePair<string, string>("badge ", "1"),
new KeyValuePair<string, string>("msg  ", "督办测试是否能收到自定义推送消息"),
new KeyValuePair<string, string>("module  ", "-2"),

new KeyValuePair<string, string>("para ",para.ToJson()),
new KeyValuePair<string, string>("hash ", Md5Helper.Md5Hex(mSByte)),
});
//                    Content temp = new Content();
//                    temp.userid = "j00xht";
//                    temp.badge = "1";
//                    temp.msg = "督办测试是否能收到自定义推送消息";
//                    temp.module = "-2";
//                    temp.para = para.ToJson();
//                    temp.hash = Md5Helper.Md5Hex(mSByte);



//                    var content3 = new FormUrlEncodedContent(new[]
//{


//new KeyValuePair<string, string>("0",temp.ToJson())

//});

                    var result = client.PostAsync("/pushMessage.do", content2).Result;

                  
                    string resultContent = result.Content.ReadAsStringAsync().Result;

                    SimpleLogUtil.WriteTextLog("督办消息", resultContent.ToString(), DateTime.Now);
                    

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }

    public class Para
    {

        public string messagetypeid;
        public string module;
        public string url;

    }

    public class Content
    {

        public string userid;
        public string badge;
        public string msg;
        public string module;
        public string para;
        public string hash;
    }
}