using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Learun.Util
{
    public class CreateImageClass
    {
        public Image ResourceImage;
        private int ImageWidth;
        private int ImageHeight;
        public string ErrMessage;
        public CreateImageClass(string ImageFileName)
        {
            FileStream fileStream = new FileStream(ImageFileName, FileMode.Open);
            Image resourceImage = Image.FromStream(fileStream);
            fileStream.Close();
            this.ResourceImage = resourceImage;
            this.ErrMessage = "";
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        public Image GetReducedImage(int Width, int Height)
        {
            Image result;
            try
            {
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallback);
                Image thumbnailImage = this.ResourceImage.GetThumbnailImage(Width, Height, callback, IntPtr.Zero);
                result = thumbnailImage;
            }
            catch (Exception ex)
            {
                this.ErrMessage = ex.Message;
                result = null;
            }
            return result;
        }
        public bool GetReducedImage(int Width, int Height, string targetFilePath)
        {
            bool result;
            try
            {
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallback);
                Image thumbnailImage = this.ResourceImage.GetThumbnailImage(Width, Height, callback, IntPtr.Zero);
                thumbnailImage.Save(targetFilePath, ImageFormat.Jpeg);
                thumbnailImage.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                this.ErrMessage = ex.Message;
                result = false;
            }
            return result;
        }
        public Image GetReducedImage(double Percent)
        {
            Image result;
            try
            {
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallback);
                this.ImageWidth = Convert.ToInt32((double)this.ResourceImage.Width * Percent);
                this.ImageHeight = Convert.ToInt32((double)this.ResourceImage.Width * Percent);
                Image thumbnailImage = this.ResourceImage.GetThumbnailImage(this.ImageWidth, this.ImageHeight, callback, IntPtr.Zero);
                result = thumbnailImage;
            }
            catch (Exception ex)
            {
                this.ErrMessage = ex.Message;
                result = null;
            }
            return result;
        }
        public bool GetReducedImage(double Percent, string targetFilePath)
        {
            bool result;
            try
            {
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallback);
                this.ImageWidth = Convert.ToInt32((double)this.ResourceImage.Width * Percent);
                this.ImageHeight = Convert.ToInt32((double)this.ResourceImage.Width * Percent);
                Image thumbnailImage = this.ResourceImage.GetThumbnailImage(this.ImageWidth, this.ImageHeight, callback, IntPtr.Zero);
                thumbnailImage.Save(targetFilePath, ImageFormat.Jpeg);
                thumbnailImage.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                this.ErrMessage = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
