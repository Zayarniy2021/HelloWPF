using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.VaryTheBackground
{
    public class VaryTheBackground: Window
    {
        //Первоначальный подход
        SolidColorBrush brush = new SolidColorBrush(Colors.Black);

        //Если сделать так, то будет ошибка, так как  объекты возвращаемые классом Brushes
        //находятся в зафиксированном состоянии
        //SolidColorBrush brush = Brushes.Black;

        //А вот так можно
        //SolidColorBrush brush = Brushes.Black.Clone();

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new VaryTheBackground());
        }

        public VaryTheBackground()
        {
            Title = "Vary the Background";
            Width = 384;
            Height = 384;
            Background = brush;
        }

        //ВАЖНО! Изменения цвета фона происходят за что того, что Brush является производным от класса
        //Freezable, который реализует событие с именем Chanded. Событие инициируется при каждом изменении объекта
        //Brush
        protected override void OnMouseMove(MouseEventArgs e)
        {
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight - SystemParameters.CaptionHeight;

            Point ptMouse = e.GetPosition(this);
            Point ptCetnter = new Point(width / 2, height / 2);
            Vector vectMouse = ptMouse - ptCetnter;
            double angle = Math.Atan2(vectMouse.Y, vectMouse.X);
            Vector vectEllipse = new Vector(width / 2 * Math.Cos(angle), height / 2 * Math.Sin(angle));
            Byte byLevel=(byte)(255*(1-Math.Min(1,vectMouse.Length/vectEllipse.Length)));
            Color clr = brush.Color;
            clr.R = clr.G = clr.B = byLevel;
            brush.Color = clr;

        }
    }
}