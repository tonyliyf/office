using System;
using System.IO;
using System.Text;

namespace Learun.Util
{
    public class FileHelper
    {
        public static bool FileCreate(string path)
        {
            bool result = false;
            FileInfo fileInfo = new FileInfo(path);
            bool flag = !fileInfo.Exists;
            if (flag)
            {
                fileInfo.Create();
                result = true;
            }
            return result;
        }
        public static bool FileCopy(string source, string destination, out string resultMessage)
        {
            resultMessage = "";
            bool flag = false;
            bool flag2 = !Directory.Exists(destination);
            if (flag2)
            {
                Directory.CreateDirectory(destination);
            }
            FileInfo fileInfo = new FileInfo(source);
            FileInfo fileInfo2 = new FileInfo(destination);
            bool exists = fileInfo.Exists;
            if (exists)
            {
                bool flag3 = !fileInfo2.Exists;
                if (flag3)
                {
                    fileInfo.CopyTo(destination);
                    flag = true;
                }
            }
            bool flag4 = flag;
            if (flag4)
            {
                resultMessage = "复制文件成功！";
            }
            else
            {
                resultMessage = "复制文件失败！";
            }
            return flag;
        }
        public static bool IsFileOpen(string filePath)
        {
            bool result = false;
            try
            {
                FileStream fileStream = File.OpenWrite(filePath);
                fileStream.Close();
            }
            catch (Exception var_2_17)
            {
                result = true;
            }
            return result;
        }
        public static bool CopyDir(string srcPath, string aimPath, out string message)
        {
            message = "";
            bool result;
            try
            {
                bool flag = aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar;
                if (flag)
                {
                    aimPath += Path.DirectorySeparatorChar.ToString();
                }
                bool flag2 = !Directory.Exists(aimPath);
                if (flag2)
                {
                    Directory.CreateDirectory(aimPath);
                }
                string[] fileSystemEntries = Directory.GetFileSystemEntries(srcPath);
                string[] array = fileSystemEntries;
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    bool flag3 = Directory.Exists(text);
                    if (flag3)
                    {
                        FileHelper.CopyDir(text, aimPath + Path.GetFileName(text), out message);
                    }
                    else
                    {
                        File.Copy(text, aimPath + Path.GetFileName(text), true);
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public static bool DeleteFolder(string dir, out string message)
        {
            message = "";
            bool flag = Directory.Exists(dir);
            bool result;
            if (flag)
            {
                string[] fileSystemEntries = Directory.GetFileSystemEntries(dir);
                for (int i = 0; i < fileSystemEntries.Length; i++)
                {
                    string text = fileSystemEntries[i];
                    bool flag2 = File.Exists(text);
                    if (flag2)
                    {
                        File.Delete(text);
                    }
                    else
                    {
                        FileHelper.DeleteFolder(text, out message);
                    }
                }
                Directory.Delete(dir);
                result = true;
            }
            else
            {
                message = message + dir + " 该文件夹不存在!";
                result = true;
            }
            return result;
        }
        public static bool DeleteFile(string dir, out string message)
        {
            bool result = true;
            message = "";
            try
            {
                bool flag = File.Exists(dir);
                if (flag)
                {
                    File.Delete(dir);
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                result = false;
            }
            return result;
        }
        public static bool GetDBSqlTemplate(string sqlFilePath, out string templateContent)
        {
            templateContent = "";
            FileStream stream = new FileStream(sqlFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            string text = streamReader.ReadToEnd();
            bool flag = text.Trim().Length < 0;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                templateContent = text;
                result = true;
            }
            return result;
        }
        public static bool ReadFile(string filePath, out string fileContent, out string error)
        {
            error = "";
            fileContent = "";
            bool result;
            try
            {
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                string text = streamReader.ReadToEnd();
                bool flag = text.Trim().Length < 0;
                if (flag)
                {
                    result = false;
                    return result;
                }
                fileContent = text;
                streamReader.Close();
            }
            catch (Exception ex)
            {
                error += ex.ToString();
            }
            result = true;
            return result;
        }
        public static bool AppendWriteFile(string filePath, string writeContent, out string error)
        {
            error = "";
            bool result;
            try
            {
                FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);
                streamWriter.WriteLine(writeContent);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                error += ex.ToString();
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public static bool CoverWriteFile(string filePath, string writeContent, out string error)
        {
            error = "";
            bool result;
            try
            {
                FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);
                streamWriter.WriteLine(writeContent);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                error += ex.ToString();
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public static bool CreateDir(string path)
        {
            bool result = false;
            bool flag = !Directory.Exists(path);
            if (flag)
            {
                Directory.CreateDirectory(path);
            }
            bool flag2 = Directory.Exists(path);
            if (flag2)
            {
                result = true;
            }
            return result;
        }
    }
}
