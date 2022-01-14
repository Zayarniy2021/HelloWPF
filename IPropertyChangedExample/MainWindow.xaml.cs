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

namespace IPropertyChangedExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = game;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            game.Finish = new Random().Next(1, 101);
        }
    }
}
