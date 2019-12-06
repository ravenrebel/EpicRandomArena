using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace EpicRandomArena.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer backgroundMusicPlayer; 
        public MainWindow()
        {
            InitializeComponent();
            StartAppAsync();
            backgroundMusicPlayer =  new MediaPlayer();
            backgroundMusicPlayer.MediaEnded += new EventHandler(Media_Ended);
            backgroundMusicPlayer.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed.");
            };
            backgroundMusicPlayer.Open(new Uri("../../Music/Mortal Kombat Theme [Remix].mp3", UriKind.RelativeOrAbsolute));

            backgroundMusicPlayer.Play();
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

        private void Media_Ended(object sender, EventArgs e)
        {
            backgroundMusicPlayer.Position = TimeSpan.Zero;
        }
    }
}
