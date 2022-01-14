using System.Windows;
namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Создаем первое окно
            MainWindow wnd = new MainWindow();
            // Определяем необходимые свойства окна
            wnd.Title = "Hello, WPF!";
            // Отображаем окно
            foreach (var param in e.Args)
                MessageBox.Show(param);
            wnd.Show();
        }
    }
}
