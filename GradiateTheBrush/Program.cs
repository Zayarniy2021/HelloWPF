using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.GradiateTheBrush
{
    public class GradiateTheBrush: Window
    {

        double angleX = 1;
        double angleY = 1;
        LinearGradientBrush brush;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new GradiateTheBrush());
        }

        public GradiateTheBrush()
        {
            Title = "Gradiate the Brush";
            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(1, 1));
            //brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 0);
            //brush = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0,0), new Point(Math.Cos(angleX), Math.Sin(angleY)));            
            Background = brush;
        }

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    switch (e.Key)
        //    {
        //        case Key.Down: angleY-=0.5;
        //            break;
        //        case Key.Up:
        //            angleY+=0.5;
        //            break;
        //        case Key.Left:
        //            angleX-=0.5;
        //            break;
        //        case Key.Right:
        //            angleX+=0.5;
        //            break;

        //    }
        //    brush = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(Math.Cos(FromAngleToRadian(angleX)), Math.Sin(FromAngleToRadian(angleY))));
        //    Background = brush;
        //    this.Title = "X=" + angleX + " Y=" + angleY;
        //    base.OnKeyDown(e);
        //}

        //double FromAngleToRadian(double angle)
        //{
        //    return angle * Math.PI / 180;
        //}
    }

}
