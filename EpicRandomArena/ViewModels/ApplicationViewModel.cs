using EpicRandomArena.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace EpicRandomArena.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Card card;

        private Models.Attribute selectedAttribute;

        public ApplicationViewModel()
        {
            Deck deck = new Deck();
            deck.Add(new Card("Ilona", "path", 9, 4, 12));
            card = deck[0];
        }

        public string Title => card.Title;

        public string Image=> card.Image;

        public string IntelligencePoints => card.Intelligence.Points.ToString();

        public string StealthPoints => card.Stealth.Points.ToString();

        public string StrengthPoints => card.Strength.Points.ToString();

        public Models.Attribute SelectedAttribute
        {
            get => selectedAttribute;
            set
            {
                selectedAttribute = value;
                OnPropertyChanged("SelectedAttribute");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand selectCommand;
        public RelayCommand SelectCommand
        {
            get
            {
                return selectCommand ??
                    (selectCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        // color that indicate lvl of attribute->func?
    }
}
