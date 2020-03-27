using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Learun.Util
{
    public class ImageHelper
    {
        public static Image GetImage(string path)
        {
            CreateImageClass createImageClass = new CreateImageClass(path);
            return createImageClass.GetReducedImage(32, 32);
        }
        public static void CaptureImage(string fromImagePath, int offsetX, int offsetY, string toImagePath, int width, int height)
        {
            Image image = Image.FromFile(fromImagePath);
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(image, 0, 0, new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
            Image image2 = Image.FromHbitmap(bitmap.GetHbitmap());
            image2.Save(toImagePath, ImageFormat.Png);
            image2.Dispose();
            graphics.Dispose();
            bitmap.Dispose();
        }
        public static void CaptureImage(Image fromImage, Rectangle rect, string toImagePath)
        {
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(fromImage, 0, 0, rect, GraphicsUnit.Pixel);
            Image image = Image.FromHbitmap(bitmap.GetHbitmap());
            image.Save(toImagePath, ImageFormat.Png);
            image.Dispose();
            graphics.Dispose();
            bitmap.Dispose();
        }
        public static Image CaptureImage(Image fromImage, Rectangle rect)
        {
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(fromImage, 0, 0, rect, GraphicsUnit.Pixel);
            Image result = Image.FromHbitmap(bitmap.GetHbitmap());
            graphics.Dispose();
            bitmap.Dispose();
            return result;
        }
        public static string ImageToByte64String(string filePath, ImageFormat format)
        {
            Bitmap bitmap = new Bitmap(filePath);
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, format);
            byte[] array = new byte[memoryStream.Length];
            memoryStream.Position = 0L;
            memoryStream.Read(array, 0, (int)memoryStream.Length);
            memoryStream.Close();
            return Convert.ToBase64String(array);
        }
        public static Image Byte64StringToImage(string picFileString)
        {
            byte[] array = Convert.FromBase64String(picFileString);
            MemoryStream memoryStream = new MemoryStream(array, 0, array.Length);
            memoryStream.Write(array, 0, array.Length);
            return Image.FromStream(memoryStream);
        }
        public static byte[] ImageToBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
        public static Image BytesToImage(byte[] bytes)
        {
            return Image.FromStream(new MemoryStream(bytes));
        }
        public static string ImageFileToBase64(string filename)
        {
            bool flag = !File.Exists(filename);
            string result;
            if (flag)
            {
                result = string.Empty;
            }
            else
            {
                Image image = Image.FromFile(filename);
                result = ImageHelper.ImageToBase64(image);
            }
            return result;
        }
        public static void Base64ToImageFile(string base64, string filename)
        {
            try
            {
                Image image = ImageHelper.Base64ToImage(base64);
                Bitmap bitmap = new Bitmap(image);
                image.Dispose();
                string directoryName = Path.GetDirectoryName(filename);
                bool flag = !Directory.Exists(directoryName);
                if (flag)
                {
                    Directory.CreateDirectory(directoryName);
                }
                bitmap.Save(filename);
            }
            catch (Exception ex)
            {
            }
        }
        public static void Base64ToImageFile(string base64, string filename, ImageFormat format)
        {
            Image image = ImageHelper.Base64ToImage(base64);
            image.Save(filename, format);
        }
        public static string ImageToBase64(Image image)
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            byte[] inArray = memoryStream.ToArray();
            memoryStream.Close();
            return Convert.ToBase64String(inArray);
        }
        public static Image Base64ToImage(string base64)
        {
            byte[] buffer = Convert.FromBase64String(base64);
            MemoryStream memoryStream = new MemoryStream(buffer);
            Image image = Image.FromStream(memoryStream);
            memoryStream.Flush();
            memoryStream.Close();
            Image result = image.Clone() as Image;
            image.Dispose();
            return result;
        }
        public static byte[] ImageToBytes(Image image, ImageFormat format)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, format);
                result = memoryStream.ToArray();
            }
            return result;
        }
    }
}
