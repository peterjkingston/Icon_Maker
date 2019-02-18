using System;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recolor_Guy
{
    class WPFBitmapConverter
    {
        public static object Convert(Bitmap ConvertFrom)
        {
            object result;

            MemoryStream ms = new MemoryStream();
            ConvertFrom.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = ms;
            bitmapImage.EndInit();

            result = bitmapImage;
            return result;
        }

    }
}
