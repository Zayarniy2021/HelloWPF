using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWrapPanelWithC_Sharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button btn = new Button();
            //btn.Visibility=Visibility.Hidden;
            btn.FontWeight = FontWeights.Bold;
            WrapPanel pnl = new WrapPanel();
            TextBlock txt = new TextBlock();
            txt.Text = "Разно";
            txt.Foreground = Brushes.Blue;
            pnl.Children.Add(txt);
            txt = new TextBlock();
            txt.Text = "цветная";
            txt.Foreground = Brushes.Red;
            pnl.Children.Add(txt);
            txt = new TextBlock();
            txt.Text = "кнопка";
            pnl.Children.Add(txt);
            btn.Content = pnl;
            pnlMain.Children.Add(btn);
        }
    }
}
