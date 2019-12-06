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
using EpicRandomArena.ViewModels;

namespace EpicRandomArena.Views
{
    /// <summary>
    /// Interaction logic for GameArea.xaml
    /// </summary>
    public partial class GameArea : Page
    {
        public GameArea() 
        {
            InitializeComponent();
        }

        private void ExitGameButton_Click(object sender, RoutedEventArgs e)
        {
            ExitGameWindow exitGameWindow = new ExitGameWindow(Window.GetWindow(this));
            exitGameWindow.Show();
        }

        private void Condition_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextTurnButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
