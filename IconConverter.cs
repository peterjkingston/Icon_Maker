using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon_Maker
{
    abstract class IconConverter
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr Handle);

        public static void SaveIcon(Bitmap Input_Bitmap)
        {
            Stream stream;
            Size sz = new Size(255, 255);
            Bitmap smaller = new Bitmap(Input_Bitmap, sz);

            IntPtr hIcon = smaller.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Icon files (*.ico)|*ico|All files (*.*)|*.*";
            saveFile.FilterIndex = 1;
            saveFile.DefaultExt = ".ico";

            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if((stream = saveFile.OpenFile()) != null)
                {
                    icon.Save(stream);
                    stream.Flush();
                    stream.Close();
                }
            }

            DestroyIcon(hIcon);
        }
    }
}
