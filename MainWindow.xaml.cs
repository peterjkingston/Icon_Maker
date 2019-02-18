using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Icon_Maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap _Bitmap;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            IconConverter.SaveIcon(_Bitmap);
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture Files|*.bmp;*.gif;*.jpg;*.png|Bitmap files (*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|JPEG Files(*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            openFile.FilterIndex = 0;

            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _Bitmap = new Bitmap(openFile.FileName);
                ImageBrush imageBrush = new ImageBrush((ImageSource)Recolor_Guy.WPFBitmapConverter.Convert(_Bitmap));

                PreviewImage.Background = imageBrush;
            }
        }
    }
}
