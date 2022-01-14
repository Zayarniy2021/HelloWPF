using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DisplaySomeText
{
    public class DisplaySomeText: Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DisplaySomeText());
        }

        public DisplaySomeText()
        {
            Title = "Display some text";
            Content = "Content can me simple text!";
            //В WPF размер шрифта задается свойством FontSize, но его значение измеряется не в
            //пунктах.
            //Как и все остальные метрики WPF, размер шрифта задается в аппаратно-зависимых единицах 1/96 дюйма.
            //Например, свойство FontSize=48 эквивалентно 36 пунктам
            FontSize = 30;
            FontFamily = new FontFamily("Comic Sans MS");
            FontStyle = FontStyles.Italic;
            FontWeight = FontWeights.Bold;
            Brush brush = new LinearGradientBrush(Colors.Black, Colors.White,45);
            Background = brush;
            Foreground = brush;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            //ResizeMode = ResizeMode.NoResize;
        }
    }
}