using EpicRandomArena.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using static EpicRandomArena.Models.Attribute;

namespace EpicRandomArena.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Card currentPlayerCard;
        private Card currentOpponentCard;

        private Kinds selectedAttribute;

        List<Card> playerDroppedCards;
        Deck playerDeck;
        Deck opponentDeck;

        private bool isYourTurn = true;
        private bool playerPositiveTurnResult = false;
        private bool evenTurnResult = false;
        private bool playerVictory = false;
        private bool opponentVictory = false;
        private bool gameInADrow = false;
        private bool turnStart = false;

        public ApplicationViewModel()
        {
            playerDeck = new Deck();
            opponentDeck = new Deck();
            Shuffle();
            playerDroppedCards = new List<Card>();
            currentPlayerCard = playerDeck[0];
            currentOpponentCard = opponentDeck[0];
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
        public int PlayerCardIntelligencePoints
        {
            get => currentPlayerCard.Intelligence.Points;
            set
            {
                currentPlayerCard.Intelligence.Points = value;
                OnPropertyChanged("PlayerCardIntelligencePoints");
            }
        }
        public int PlayerCardStealthPoints
        {
            get => currentPlayerCard.Stealth.Points;
            set
            {
                currentPlayerCard.Stealth.Points = value;
                OnPropertyChanged("PlayerCardStealthPoints");
            }
        }
        public int PlayerCardStrengthPoints
        {
            get => currentPlayerCard.Strength.Points;
            set
            {
                currentPlayerCard.Strength.Points = value;
                OnPropertyChanged("PlayerCardStrengthPoints");
            }
        }
        public Levels PlayerCardIntelligenceLevel
        {
            get => currentPlayerCard.Intelligence.Level;
            set
            {
                currentPlayerCard.Intelligence.Level = value;
                OnPropertyChanged("PlayerCardIntelligenceLevel");
            }
        }
        public Levels PlayerCardStealthLevel
        {
            get => currentPlayerCard.Stealth.Level;
            set
            {
                currentPlayerCard.Stealth.Level = value;
                OnPropertyChanged("PlayerCardStealthLevel");
            }
        }
        public Levels PlayerCardStrengthLevel
        {
            get => currentPlayerCard.Strength.Level;
            set
            {
                currentPlayerCard.Strength.Level = value;
                OnPropertyChanged("PlayerCardStrengthLevel");
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
        public int OpponentCardIntelligencePoints
        {
            get => currentOpponentCard.Intelligence.Points;
            set
            {
                currentOpponentCard.Intelligence.Points = value;
                OnPropertyChanged("OpponentCardIntelligencePoints");
            }
        }
        public int OpponentCardStealthPoints
        {
            get => currentOpponentCard.Stealth.Points;
            set
            {
                currentOpponentCard.Stealth.Points = value;
                OnPropertyChanged("OpponentCardStealthPoints");
            }
        }
        public int OpponentCardStrengthPoints
        {
            get => currentOpponentCard.Strength.Points;
            set
            {
                currentOpponentCard.Strength.Points = value;
                OnPropertyChanged("OpponentCardStrengthPoints");
            }
        }
        public Levels OpponentCardIntelligenceLevel
        {
            get => currentOpponentCard.Intelligence.Level;
            set
            {
                currentOpponentCard.Intelligence.Level = value;
                OnPropertyChanged("OpponentCardIntelligenceLevel");
            }
        }
        public Levels OpponentCardStealthLevel
        {
            get => currentOpponentCard.Stealth.Level;
            set
            {
                currentOpponentCard.Stealth.Level = value;
                OnPropertyChanged("OpponentCardStealthLevel");
            }
        }
        public Levels OpponentCardStrengthLevel
        {
            get => currentOpponentCard.Strength.Level;
            set
            {
                currentOpponentCard.Strength.Level = value;
                OnPropertyChanged("OpponentCardStrengthLevel");
            }
        }

        public Kinds SelectedAttribute
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
        public bool OpponentVictory
        {
            get => opponentVictory;
            set
            {
                opponentVictory = value;
                OnPropertyChanged("OpponentVictory");
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
                            selectedAttribute = Kinds.Strength;
                        else if (kind == "Strelth")
                            selectedAttribute = Kinds.Stealth;
                        else selectedAttribute =Kinds.Intelligence;

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
                        TurnResult();
                       
                        TurnStart = false;
                        selectedAttribute = AIChoice();

                        TurnResult(); 
                        IsYourTurn = true;
                    }));
            }
        }

        private void Turn()
        {
            currentPlayerCard = playerDeck[0];
            currentOpponentCard = opponentDeck[0];

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
                playerDroppedCards.Add(currentPlayerCard);
                opponentDeck.Add(currentOpponentCard);
                PlayerPositiveTurnResult = false;
                EvenTurnResult = true;
            }
        }

        private void TurnResult()
        {
            try
            {
                Turn();

                if (playerDeck.Count() == 0) OpponentVictory = true;
                else if (playerDeck.Count() == 1 && opponentDeck.Count() == 1
                            && playerDeck[0] == opponentDeck[0]) GameInADraw = true;
                else if (opponentDeck.Count() == 0) PlayerVictory = true;
                else
                {
                    PlayerCardTitle = playerDeck[0].Title;
                    PlayerCardImage = playerDeck[0].Image;
                    PlayerCardIntelligencePoints = playerDeck[0].Intelligence.Points;
                    PlayerCardStealthPoints = playerDeck[0].Stealth.Points;
                    PlayerCardStrengthPoints = playerDeck[0].Strength.Points;
                    PlayerCardIntelligenceLevel = playerDeck[0].Intelligence.Level;
                    PlayerCardStealthLevel = playerDeck[0].Stealth.Level;
                    PlayerCardStrengthLevel = playerDeck[0].Strength.Level;

                    OpponentCardTitle = opponentDeck[0].Title;
                    OpponentCardImage = opponentDeck[0].Image;
                    OpponentCardIntelligencePoints = opponentDeck[0].Intelligence.Points;
                    OpponentCardStealthPoints = opponentDeck[0].Stealth.Points;
                    OpponentCardStrengthPoints = opponentDeck[0].Strength.Points;
                    OpponentCardIntelligenceLevel = opponentDeck[0].Intelligence.Level;
                    OpponentCardStealthLevel = opponentDeck[0].Stealth.Level;
                    OpponentCardStrengthLevel = opponentDeck[0].Strength.Level;

                    TurnStart = true;
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private Models.Attribute.Kinds AIChoice()
        {
            return Models.Attribute.Kinds.Intelligence;
        }

        private void Shuffle()
        {
            Random rng = new Random();
            int deckCount = opponentDeck.Count();
            bool isAtLeastOneEqual = true;

            while (isAtLeastOneEqual)
            {
                isAtLeastOneEqual = false;
                for (int i = 0; i < deckCount; i++)
                {
                    if (playerDeck[i] == (opponentDeck[i]))
                    {
                        int playerCardIndex = rng.Next(deckCount);
                        int opponentCardIndex;
                        do opponentCardIndex = rng.Next(deckCount);
                        while (opponentCardIndex == playerCardIndex);

                        Card playerCard = playerDeck[playerCardIndex];
                        playerDeck[playerCardIndex] = playerDeck[i];
                        playerDeck[i] = playerCard;

                        Card opponentCard = opponentDeck[opponentCardIndex];
                        opponentDeck[opponentCardIndex] = opponentDeck[i];
                        opponentDeck[i] = opponentCard;
                        isAtLeastOneEqual = true;
                    }
                }
            }
        }
    }
}
