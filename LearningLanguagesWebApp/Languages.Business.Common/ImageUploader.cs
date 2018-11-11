using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Languages.Common.Constants;

namespace Languages.Business.Common
{
    public class ImageUploader : IImageUploader
    {
        public Image Base64ToImage(string base64String)
        {
            string base64 = ParseStringBase64(base64String);
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                //image.Save(filePath);         //save image
                return image;
            }
        }

        public string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private string ParseStringBase64(string base64String)
        {
            var result = base64String;
            var split = base64String.Split(new string[] { Constants.Base64 }, StringSplitOptions.None);
            if(split.Length == 2)
            {
                result = split[1].Substring(1);
            }
            return result;
        }
    }
}
