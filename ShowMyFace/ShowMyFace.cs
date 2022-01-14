//-------------------------------------------
// ShowMyFace.cs (c) 2006 by Charles Petzold
//-------------------------------------------
using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.ShowMyFace
{
    class ShowMyFace : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ShowMyFace());
        }
        public ShowMyFace()
        {
            Title = "Show My Face";

            Uri uri = new Uri("http://www.charlespetzold.com/PetzoldTattoo.jpg");
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            img.Source = bitmap;
            img.Opacity = 0.5;
            Background = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(1, 1));
            Content = img;

        }
    }
}
