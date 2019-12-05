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

namespace EpicRandomArena.Views
{
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ExitGameWindow exitGameWindow = new ExitGameWindow(Window.GetWindow(this));
            exitGameWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Text = "Not a long time ago in a galaxy not very far away, scientists were searching for the Higgs boson. The Large Hadron Collider generated a large number of small black holes that became portals to many parallel Universes. This is how humanity met with foreigners and the First Universes War began. Heroes and villains made their choice: peaceful coexistence or the struggle for resources.";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextInfo.Text = "Each card has three characteristics: intelligence, physical strength, stealth. Each characteristic is in one of the ranges: low level: 1-5, middle: 6 - 10, high: 11 - 15.If the characteristics are the same level, the card is stronger when the value is greater. Low → strong → medium → low. Players get one card at a time.One of the players chooses one of the characteristics, if it 'hits' the same on the opponent's card, its card is dropped and the winning card gets mixed back into player's deck. If the characteristics are the same, two cards are randomly mixed into the deck.The one who has no cards left loses.";
        }
    }
}
