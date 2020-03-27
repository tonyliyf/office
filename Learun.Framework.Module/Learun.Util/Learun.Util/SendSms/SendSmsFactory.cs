using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.SendSms
{
    public class SendSmsFactory
    {
        public static SendSmsBase CreateFactory(string className,string smsName,string smsKey)
        {
            SendSmsBase sendsms = null;
            switch (className)
            {
                case "WJSendSms":
                    sendsms = new WJSendSms(smsName,smsKey);
                    break;
                case "DXTSMSsend":
                    sendsms = new DXTSMSsend();
                    break;
                default:
                    sendsms = null;
                    break;

            }
            return sendsms;
        }
    }
    public class SendSmsBase
    {
        public string Name { get; set; } //用户名
        public string Key { get; set; } //接口秘钥
        public virtual string SendSmsInfo(string smsMob, string smsText)
        {
            return string.Empty;
        }

        public virtual bool SendSms(string smsMob, string smsText)
        {
            return false;
        }

    }
    public class WJSendSms : SendSmsBase
    {
        //平台地址 http://www.smschinese.cn/

        public WJSendSms()
        {
            Name = "decheng"; //用户名
            Key = "d41d8cd98f00b204e980"; //接口秘钥
        }


        public WJSendSms(string name ,string key)
        {
            Name = name; //用户名
            Key  = key; //接口秘钥
        }
        public override string SendSmsInfo(string smsMob, string smsText)
        {
            string url = "http://utf8.sms.webchinese.cn/?Uid=" + Name + "&key=" + Key + "&smsMob=" + smsMob + "&smsText=" + smsText;
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return GetResult(strRet);
        }


        public  override bool SendSms(string smsMob, string smsText)
        {
            string url = "http://utf8.sms.webchinese.cn/?Uid=" + Name + "&key=" + Key + "&smsMob=" + smsMob + "&smsText=" + smsText;
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return false;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                
                strRet = null;
                return false;
            }
            int  itemp = int.Parse(strRet);
            return itemp > 0;
        }
        /// <summary>确认返回信息 </summary>
        public string GetResult(string strRet)
        {
            int result = 0;
            try
            {
                result = int.Parse(strRet);
                switch (result)
                {
                    case -1:
                        strRet = "没有该用户账户";
                        break;
                    case -2:
                        strRet = "接口密钥不正确,不是账户登陆密码";
                        break;
                    case -21:
                        strRet = "MD5接口密钥加密不正确";
                        break;
                    case -3:
                        strRet = "账户余额不足";
                        break;
                    case -11:
                        strRet = "该用户被禁用";
                        break;
                    case -14:
                        strRet = "短信内容出现非法字符";
                        break;
                    case -4:
                        strRet = "手机号格式不正确";
                        break;
                    case -41:
                        strRet = "手机号码为空";
                        break;
                    case -42:
                        strRet = "短信内容为空";
                        break;
                    case -51:
                        strRet = "短信签名格式不正确,接口签名格式为：【签名内容】";
                        break;
                    case -6:
                        strRet = "IP限制";
                        break;
                    default:
                        strRet = "发送短信数量：" + result;
                        break;
                }
            }
            catch (Exception ex)
            {
                strRet = ex.Message;
            }
            return strRet;
        }
    }
    public class DXTSMSsend : SendSmsBase
    {
        //平台地址 http://www.106jiekou.com/

        public DXTSMSsend()
        {
            Name = "decheng";
            Key = "d41d8cd98f00b204e980";
        }
        public override string SendSmsInfo(string mobile, string content)
        {
            string PostUrl = "http://sms.106jiekou.com/utf8/sms.aspx";
            string returncode = string.Empty;
            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, Name, Key, mobile, content));
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            myRequest.ContentLength = postData.Length;
            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                returncode = reader.ReadToEnd();

            }
            else
            {
                returncode = "000";
            }
            return GetResult(returncode);
        }
        public string GetResult(string returncode)
        {
            string returntext = string.Empty;
            switch (Convert.ToInt32(returncode))
            {
                case 100:
                    returntext = "发送成功";
                    break;
                case 101:
                    returntext = "验证失败";
                    break;
                case 102:
                    returntext = "手机号码格式不正确";
                    break;
                case 103:
                    returntext = "会员级别不够";
                    break;
                case 104:
                    returntext = "内容未审核";
                    break;
                case 105:
                    returntext = "内容过多";
                    break;
                case 106:
                    returntext = "账户余额不足";
                    break;
                case 107:
                    returntext = "Ip受限";
                    break;
                case 108:
                    returntext = "手机号码发送太频繁，请换号或隔天再发";
                    break;
                case 109:
                    returntext = "帐号被锁定";
                    break;
                case 110:
                    returntext = "手机号发送频率持续过高，黑名单屏蔽数日";
                    break;
                case 120:
                    returntext = "系统升级";
                    break;
                default:
                    returntext = "访问失败";
                    break;
            }
            return returntext;

        }
    }

    //SendSmsBase SmsClass = new SendSmsBase();
    //SmsClass = SendSmsFactory.CreateFactory("DXTSMSsend");
    //                string content = "您的手机号：" + model.Phone + "，注册验证码：" + code + "，一天内提交有效，如不是本人操作请忽略！";
    //returncode=SmsClass.SendSmsInfo(model.Phone, content);
    //                if (returncode == "账户余额不足")
    //                {

    //                   SmsClass = SendSmsFactory.CreateFactory("WJSendSms");
    //                    SmsClass.SendSmsInfo(model.Phone, content);
    //                }
}
