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
using System.Windows.Shapes;

namespace EpicRandomArena.Views
{
    /// <summary>
    /// Interaction logic for ExitGameWindow.xaml
    /// </summary>
    public partial class ExitGameWindow : Window
    {
        Window mainWindow;

        public ExitGameWindow(Window window)
        {
            mainWindow = window;
            if (mainWindow != null)
                mainWindow.IsEnabled = false;
            Owner = mainWindow;
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            mainWindow.IsEnabled = true;
        }

        private void ExitToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MenuPage menuPage = new MenuPage();
            mainWindow.Content = menuPage.Content;
        }

        private void ExitToDesktop_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.IsEnabled = true;
        }
    }
}
