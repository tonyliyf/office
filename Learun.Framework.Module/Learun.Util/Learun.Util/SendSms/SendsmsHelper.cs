using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.SendSms
{
    public class SendsmsHelper
    {

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        private static string smsOpen = Config.GetValue("SMSOpen");

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        private static string smsName = Config.GetValue("SMSNAME");
        /// <summary>
        /// 用户名
        /// </summary>
        private static string smsKey = Config.GetValue("SMSKEY");
       

        public static  bool SendSms(string smsMob, string smsText)
        {
            if (string.IsNullOrEmpty(smsOpen) || smsOpen.ToLower() == "true")
            {
                SendSmsBase SmsClass = new SendSmsBase();
                SmsClass = SendSmsFactory.CreateFactory("WJSendSms", smsName, smsKey);
                return SmsClass.SendSms(smsMob, smsText);
            }
            return false;


        }
    }
}
