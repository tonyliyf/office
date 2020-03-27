using Microsoft.Win32;
using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Learun.Util
{
    public class RSAHelper
    {
        public void RSAKey(string PrivateKeyPath, string PublicKeyPath)
        {
            try
            {
                RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                CreatePrivateKeyXML(PrivateKeyPath, rSACryptoServiceProvider.ToXmlString(true));
                CreatePublicKeyXML(PublicKeyPath, rSACryptoServiceProvider.ToXmlString(false));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetHash(string m_strSource)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(m_strSource);
            byte[] inArray = hashAlgorithm.ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        public string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            try
            {
                RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                rSACryptoServiceProvider.FromXmlString(xmlPublicKey);
                byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
                return Convert.ToBase64String(rSACryptoServiceProvider.Encrypt(bytes, false));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            try
            {
                RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                rSACryptoServiceProvider.FromXmlString(xmlPrivateKey);
                byte[] rgb = Convert.FromBase64String(m_strDecryptString);
                byte[] bytes = rSACryptoServiceProvider.Decrypt(rgb, false);
                return new UnicodeEncoding().GetString(bytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature)
        {
            byte[] rgbHash = Convert.FromBase64String(m_strHashbyteSignature);
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.FromXmlString(p_strKeyPrivate);
            RSAPKCS1SignatureFormatter rSAPKCS1SignatureFormatter = new RSAPKCS1SignatureFormatter(rSACryptoServiceProvider);
            rSAPKCS1SignatureFormatter.SetHashAlgorithm("MD5");
            byte[] inArray = rSAPKCS1SignatureFormatter.CreateSignature(rgbHash);
            return Convert.ToBase64String(inArray);
        }

        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
        {
            try
            {
                if (!string.IsNullOrEmpty(p_strDeformatterData) && !string.IsNullOrEmpty(p_strDeformatterData))
                {
                    byte[] rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);
                    RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
                    rSACryptoServiceProvider.FromXmlString(p_strKeyPublic);
                    RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rSACryptoServiceProvider);
                    rSAPKCS1SignatureDeformatter.SetHashAlgorithm("MD5");
                    byte[] rgbSignature = Convert.FromBase64String(p_strDeformatterData);
                    if (rSAPKCS1SignatureDeformatter.VerifySignature(rgbHash, rgbSignature))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public string GetHardID()
        {
            string result = "";
            ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection instances = managementClass.GetInstances();
            foreach (ManagementObject item in instances)
            {
                result = (string)item.Properties["Model"].Value;
            }
            return result;
        }

        private string ReadReg(string key)
        {
            string text = "";
            try
            {
                RegistryKey localMachine = Registry.LocalMachine;
                RegistryKey registryKey = localMachine.OpenSubKey("SOFTWARE/JX/Register");
                text = registryKey.GetValue(key).ToString();
                registryKey.Close();
                localMachine.Close();
                return text;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteReg(string key, string value)
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE/JX/Register");
                registryKey.SetValue(key, value);
                registryKey.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreatePublicKeyXML(string path, string publickey)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(publickey);
                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
                throw;
            }
        }

        public void CreatePrivateKeyXML(string path, string privatekey)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(privatekey);
                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
                throw;
            }
        }

        public void CreateAccredFile(string path, string cdk)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(cdk);
                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
                throw;
            }
        }

        public string ReadPublicKey(string path)
        {
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                return result;
            }
            catch
            {
                return "";
            }
        }

        public string ReadPrivateKey(string path)
        {
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public string ReadAccreditFile(string path)
        {
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                return result;
            }
            catch
            {
                return "";
            }
        }

        public void InitialReg(string path)
        {
            Registry.LocalMachine.CreateSubKey("SOFTWARE/JX/Register");
            Random random = new Random();
            string value = ReadPublicKey(path);
            if (Registry.LocalMachine.OpenSubKey("SOFTWARE/JX/Register").ValueCount <= 0)
            {
                WriteReg("RegisterRandom", random.Next(1, 100000).ToString());
                WriteReg("RegisterPublicKey", value);
            }
            else
            {
                WriteReg("RegisterPublicKey", value);
            }
        }

        public string Encrypt(string str)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Unicode.GetBytes("Oyea");
            byte[] bytes2 = Encoding.Unicode.GetBytes(str);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            cryptoStream.Write(bytes2, 0, bytes2.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public string Decrypt(string str)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Unicode.GetBytes("Oyea");
            byte[] array = Convert.FromBase64String(str.Trim());
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);

            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Encoding.Unicode.GetString(memoryStream.ToArray());
        }
    }
}
