using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;
/*
При прорисовке кнопки графическая подсистема WPF использует предоставленные пользователем сведения для закраски группы пикселей, чтобы задать внешний вид кнопки. Хотя пользователь использует заливку сплошным цветом для описания внешнего вида кнопки, фактически не она выполняет закраску. Графическая система создает быстрые низкоуровневые объекты для кнопки и кисти, и именно эти объекты фактически отображаются на экране.
При изменении кисти эти низкоуровневые объекты необходимо обновлять. Именно класс Freezable дает кисти возможность найти соответствующие ей низкоуровневые объекты и обновить их, когда она изменяется. Если эта возможность включена, кисть считается "незафиксированной".
Метод Freezable Freeze позволяет отключить данную возможность самостоятельного обновления. Этот метод позволяет "зафиксировать" кисть, т.е. сделать ее неизменяемой.
*/
//https://msdn.microsoft.com/ru-ru/library/ms750509(v=vs.110).aspx
namespace Zayarniy.Sample
{
    class Program : Window
    {
        [STAThread]
        static void Main()
        {
            Application app = new Application();
            app.Run(new Program());
        }

        public Program()
        {
            Title = "Freezable sample";
            Width = 400;
            Height = 400;
            Background = System.Windows.Media.Brushes.Aqua;
            Button myButton = new Button();
            myButton.Width = 100;
            myButton.Height = 100;
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
            myButton.Background = myBrush;
            this.Content = myButton;
            if (myBrush.CanFreeze)
            {
                myBrush.Freeze();
            }

        }
    }
}
