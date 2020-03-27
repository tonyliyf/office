using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Learun.Util
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.04
    /// 描 述：数据访问(SqlServer) 上下文
    /// </summary>
    public class Md5Helper
    {
        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string Encrypt(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = Hash(str).Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = Hash(str);
            }
            return strEncrypt;
        }
        /// <summary>
        /// 32位MD5加密（小写）
        /// </summary>
        /// <param name="input">输入字段</param>
        /// <returns></returns>
        public static string Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        #endregion


        private static char[] toDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        public static string Md5Hex(string I_SourceArray)
        {
            string R_Result;

            byte[] temp = Encoding.UTF8.GetBytes(I_SourceArray);
            sbyte[] temp1 = Md5Helper.ByteArray2SByteArray(temp);
            R_Result = Md5Hex(temp1);

            return R_Result;
        }

        public static string Md5Hex(sbyte[] I_SourceArray)
        {
            string R_Result;

            sbyte[] md5SByteArray = Md5Helper.Md5Encode(I_SourceArray);
            char[] charArray = Md5Helper.EncodeHex(md5SByteArray);

            R_Result = new string(charArray);
            return R_Result;
        }

  


        private static sbyte[] Md5Encode(sbyte[] I_Source)
        {
            sbyte[] R_Result;

            byte[] temp = Md5Helper.SByteArray2ByteArray(I_Source);
            byte[] temp1 = new MD5CryptoServiceProvider().ComputeHash(temp);
            R_Result = Md5Helper.ByteArray2SByteArray(temp1);

            return R_Result;
        }


        private static char[] EncodeHex(sbyte[] data)
        {
            int l = data.Length;
            char[] R_Result = new char[l << 1];
            for (int i = 0, j = 0; i < l; i++)
            {
                R_Result[j++] = toDigits[Md5Helper.MoveByte((0xF0 & data[i]), 4)];
                R_Result[j++] = toDigits[0x0F & data[i]];
            }
            return R_Result;
        }

        private static int MoveByte(int value, int pos)
        {
            if (value < 0)
            {
                string s = Convert.ToString(value, 2);
                for (int i = 0; i < pos; i++)
                {
                    s = "0" + s.Substring(0, 31);
                }
                return Convert.ToInt32(s, 2);
            }
            else
            {
                return value >> pos;
            }
        }


        private static sbyte[] ByteArray2SByteArray(byte[] I_SourceByte)
        {
            return I_SourceByte.Select(p => Md5Helper.Byte2SByte(p)).ToArray();
        }

        private static byte[] SByteArray2ByteArray(sbyte[] I_SourceByte)
        {
            return I_SourceByte.Select(p => Md5Helper.SByte2Byte(p)).ToArray();
        }


        private static sbyte Byte2SByte(byte I_SourceSByte)
        {
            sbyte R_Result;

            if (I_SourceSByte < 128)
            {
                R_Result = (sbyte)I_SourceSByte;
            }
            else
            {
                R_Result = (sbyte)(I_SourceSByte - 256);
            }
            return R_Result;
        }


        private static byte SByte2Byte(sbyte I_SourceSByte)
        {
            byte R_Result;

            if (I_SourceSByte < 0)
            {
                R_Result = (byte)(I_SourceSByte + 256);
            }
            else
            {
                R_Result = (byte)I_SourceSByte;
            }
            return R_Result;
        }
    }
}
