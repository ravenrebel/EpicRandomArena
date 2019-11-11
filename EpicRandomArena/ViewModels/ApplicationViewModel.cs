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

        List<Card> playerDroppedCards;
        Deck playerDeck;
        Deck opponentDeck;

        private bool isYourTurn = true;
        private bool playerPositiveTurnResult = false;
        private bool evenTurnResult = false;
        private bool playerVictory = false;
        private bool gameInADrow = false;
        private bool turnStart = false;

        public ApplicationViewModel()
        {
            playerDeck = new Deck();
            opponentDeck = new Deck();
            playerDroppedCards = new List<Card>();
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
        public bool PlayerPositiveTurnResult
        {
            get => playerPositiveTurnResult;
            set
            {
                playerPositiveTurnResult = value;
                OnPropertyChanged("PlayerPositiveTurnResult");
            }
        }
        public bool EvenTurnResult
        {
            get => evenTurnResult;
            set
            {
               evenTurnResult = value;
                OnPropertyChanged("EvenTurnResult");
            }
        }
        public bool PlayerVictory
        {
            get => playerVictory;
            set
            {
               playerVictory = value;
                OnPropertyChanged("PlayerVictory");
            }
        }
        public bool GameInADraw
        {
            get => gameInADrow;
            set
            {
                gameInADrow = value;
                OnPropertyChanged("GameInADraw");
            }
        }
        public bool TurnStart
        {
            get => turnStart;
            set
            {
                turnStart = value;
                OnPropertyChanged("TurnStart");
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
                        TurnStart = false;
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
                        TurnStart = false;
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
                playerDroppedCards.Add(currentOpponentCard);
                playerDeck.Add(currentPlayerCard);
                PlayerPositiveTurnResult = true;
                EvenTurnResult = false;
            }
            else if (currentOpponentCard.IsGreater(currentPlayerCard, selectedAttribute))
            {
                playerDroppedCards.Add(currentPlayerCard);
                opponentDeck.Add(currentOpponentCard);
                PlayerPositiveTurnResult = false;
                EvenTurnResult = false;
            }
            else
            {
                playerDeck.RandomShove(currentPlayerCard);
                opponentDeck.RandomShove(currentOpponentCard);
                PlayerPositiveTurnResult = false;
                EvenTurnResult = true;
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
                            && playerDeck.TopCard == opponentDeck.TopCard) GameInADraw = true;
                else if (opponentDeck.Count() == 0) PlayerVictory = true;
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

                    TurnStart = true;
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private Models.Attribute.Kinds AIChoice()
        {
            return Models.Attribute.Kinds.Intelligence;
        }
    }
}
