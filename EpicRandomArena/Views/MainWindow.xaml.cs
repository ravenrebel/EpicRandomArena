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
using System.Windows.Threading;

namespace EpicRandomArena.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartAppAsync();
        }

        private async void StartAppAsync()
        {
            Content = new LoadingPage();

            Action showMenu = delegate ()
            {
                MenuPage menuPage = new MenuPage(); 
                Content = menuPage.Content;
            };

            await Task.Run(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  showMenu);
            }).ConfigureAwait(true);

        }
    }
}
