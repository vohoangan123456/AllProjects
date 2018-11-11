using System.Drawing;
using System.Drawing.Imaging;

namespace Languages.Business.Common
{
    public interface IImageUploader
    {
        Image Base64ToImage(string base64String);
        string ImageToBase64(Image image, ImageFormat format);
    }
}
