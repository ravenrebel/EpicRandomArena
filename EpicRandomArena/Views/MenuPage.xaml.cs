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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using EpicRandomArena.ViewModels;

namespace EpicRandomArena
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        { 
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();
        }

        private async void PlayButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Content = new Views.LoadingPage();

            await Task.Run(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  new Action(() => _NavigationFrame.Content = new Views.GameArea()));
            }).ConfigureAwait(true);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Content = new Views.InfoPage();
        }
    }
}
