using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Petzold.RotateTheGradientOrigin
{
    class RotateTheGradientOrigin : Window
    {
        RadialGradientBrush brush;
        double angle;

        [STAThread]
        static void Main()
        {
            Application app = new Application();
            app.Run(new RotateTheGradientOrigin());
        }

        public RotateTheGradientOrigin()
        {
            Title = "Rotate The Gradient Origin";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Width = 384;//4 inch
            Height = 384;
            BorderBrush = new LinearGradientBrush(Colors.Red,Colors.Purple, 40);
            BorderThickness = new Thickness(25, 50, 75, 100);
            brush = new RadialGradientBrush(Colors.Red, Colors.Blue);
            brush.Center = brush.GradientOrigin = new Point(0.5, 0.5);
            brush.RadiusX = brush.RadiusY = 0.10;
            //brush.MappingMode = BrushMappingMode.Absolute;
            Background = brush;

            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromMilliseconds(100);
            tmr.Tick += Tmr_Tick;
            tmr.Start();
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            Point pt = new Point(0.5 + 0.05 * Math.Cos(angle), 0.5 + 0.05 * Math.Sin(angle));
            brush.GradientOrigin = pt;
            angle += Math.PI / 6;//То есть 30 градусов
        }
    }
}