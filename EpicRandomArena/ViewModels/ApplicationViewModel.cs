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
        private Card currentPlayerCard;
        private Card currentOpponentCard;

        private Models.Attribute.Kinds selectedAttribute;

        List<Card> droppedCards;
        Deck playerDeck;
        Deck opponentDeck;

        private bool isYourTurn = true;

        public ApplicationViewModel()
        {
            playerDeck = new Deck();
            playerDeck.Add(new Card("Ilona", "/EpicRandomArena;component/Graphics/Ilona.jpg", 9, 4, 12));
            playerDeck.Add(new Card("Nastya", "path", 8, 1, 14));

            opponentDeck = new Deck();
            opponentDeck.Add(new Card("Ilona", "/EpicRandomArena;component/Graphics/Ilona.jpg", 9, 4, 12));
            opponentDeck.Add(new Card("Batman", "path", 14, 9, 9));

            droppedCards = new List<Card>();

            currentPlayerCard = playerDeck.TopCard;
        }

        public string PlayerCardTitle
        {
            get => currentPlayerCard.Title;
            set
            {
                currentPlayerCard.Title = value;
                OnPropertyChanged("PlayerCardTitle");
            }
        }
        public string PlayerCardImage
        {
            get => currentPlayerCard.Image;
            set
            {
                currentPlayerCard.Image = value;
                OnPropertyChanged("PlayerCardImage");
            }
        }
        public string PlayerCardIntelligencePoints
        {
            get => currentPlayerCard.Intelligence.Points.ToString();
            set
            {
                currentPlayerCard.Intelligence.Points = Convert.ToInt32(value);
                OnPropertyChanged("PlayerCardIntelligencePoints");
            }
        }
        public string PlayerCardStealthPoints
        {
            get => currentPlayerCard.Stealth.Points.ToString();
            set
            {
                currentPlayerCard.Stealth.Points = Convert.ToInt32(value);
                OnPropertyChanged("PlayerCardStealthPoints");
            }
        }
        public string PlayerCardStrengthPoints
        {
            get => currentPlayerCard.Strength.Points.ToString();
            set
            {
                currentPlayerCard.Strength.Points = Convert.ToInt32(value);
                OnPropertyChanged("PlayerCardStrengthPoints");
            }
        }


        public string OpponentCardTitle
        {
            get => currentOpponentCard.Title;
            set
            {
                currentOpponentCard.Title = value;
                OnPropertyChanged("OpponentCardTitle");
            }
        }
        public string OpponentCardImage
        {
            get => currentOpponentCard.Image;
            set
            {
                currentOpponentCard.Image = value;
                OnPropertyChanged("OpponentCardImage");
            }
        }
        public string OpponentCardIntelligencePoints
        {
            get => currentOpponentCard.Intelligence.Points.ToString();
            set
            {
                currentPlayerCard.Intelligence.Points = Convert.ToInt32(value);
                OnPropertyChanged("OpponentCardIntelligencePoints");
            }
        }
        public string OpponentCardStealthPoints
        {
            get => currentOpponentCard.Strength.Points.ToString();
            set
            {
                currentPlayerCard.Strength.Points = Convert.ToInt32(value);
                OnPropertyChanged("OpponentCardStealthPoints");
            }
        }
        public string OpponentCardStrengthPoints
        {
            get => currentOpponentCard.Strength.Points.ToString();
            set
            {
                currentPlayerCard.Strength.Points = Convert.ToInt32(value);
                OnPropertyChanged("OpponentCardStrengthPoints");
            }
        }

        public Models.Attribute.Kinds SelectedAttribute
        {
            get => selectedAttribute;
            set
            {
                selectedAttribute = value;
                OnPropertyChanged("SelectedAttribute");
            }
        }

        public bool IsYourTurn
        {
            get => isYourTurn;
            set
            {
                isYourTurn = value;
                OnPropertyChanged("IsYourTurn");
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
                        string kind = obj as string;

                        if (kind == "Strength")
                            selectedAttribute = Models.Attribute.Kinds.Strength;
                        else if (kind == "Strelth")
                            selectedAttribute = Models.Attribute.Kinds.Stealth;
                        else selectedAttribute = Models.Attribute.Kinds.Intelligence;

                        TurnResult();
                        IsYourTurn = false;
                    }));
            }
        }

        private RelayCommand botSelectCommand;
        public RelayCommand BotSelectCommand
        {
            get
            {
                return botSelectCommand ??
                    (botSelectCommand = new RelayCommand(obj =>
                    {
                        selectedAttribute = AIChoice();

                        TurnResult();
                        IsYourTurn = true;
                    }));
            }
        }

        private void Turn()
        {
            currentPlayerCard = playerDeck.TopCard;
            currentOpponentCard = opponentDeck.TopCard;

            playerDeck.Drop();
            opponentDeck.Drop();
            if (currentPlayerCard.IsGreater(currentOpponentCard, selectedAttribute))
            {
                droppedCards.Add(currentOpponentCard);
                playerDeck.Add(currentPlayerCard);
            }
            else if (currentOpponentCard.IsGreater(currentPlayerCard, selectedAttribute))
            {
                droppedCards.Add(currentPlayerCard);
                opponentDeck.Add(currentOpponentCard);
            }
            else
            {
                Console.WriteLine("It works!");
                playerDeck.RandomShove(currentPlayerCard);
                opponentDeck.RandomShove(currentOpponentCard);
            }
        }

        private void TurnResult()
        {
            try
            {
                Turn();

                if (playerDeck.Count() == 0)
                {
                    Console.WriteLine("Game over");
                }
                else if (playerDeck.Count() == 1 && opponentDeck.Count() == 1
                            && playerDeck.TopCard == opponentDeck.TopCard) Console.WriteLine("Friendship won");
                else if (opponentDeck.Count() == 0) Console.WriteLine("You won!");
                else
                {
                    PlayerCardTitle = playerDeck.TopCard.Title;
                    PlayerCardImage = playerDeck.TopCard.Image;
                    PlayerCardIntelligencePoints = playerDeck.TopCard.Intelligence.Points.ToString();
                    PlayerCardStealthPoints = playerDeck.TopCard.Stealth.Points.ToString();
                    PlayerCardStrengthPoints = playerDeck.TopCard.Strength.Points.ToString();

                    OpponentCardTitle = opponentDeck.TopCard.Title;
                    OpponentCardImage = opponentDeck.TopCard.Image;
                    OpponentCardIntelligencePoints = opponentDeck.TopCard.Intelligence.Points.ToString();
                    OpponentCardStealthPoints = opponentDeck.TopCard.Stealth.Points.ToString();
                    OpponentCardStrengthPoints = opponentDeck.TopCard.Strength.Points.ToString();
                }
            }
            catch (Exception) { }
        }

        private Models.Attribute.Kinds AIChoice()
        {
            return Models.Attribute.Kinds.Intelligence;
        }
    }
}
