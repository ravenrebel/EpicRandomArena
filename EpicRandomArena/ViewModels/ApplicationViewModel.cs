using EpicRandomArena.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static EpicRandomArena.Models.Attribute;

namespace EpicRandomArena.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Card currentPlayerCard;
        private Card currentOpponentCard;

        private Kinds selectedAttribute;

        int playerHighLevelDroppedCardsCount = 0;
        int playerMiddleLevelDroppedCardsCount = 0;
        int playerLowLevelDroppedCardsCount = 0;
        int playerDeckCount;
        int opponentDeckCount;

        Deck playerDeck;
        Deck opponentDeck;

        private bool isYourTurn;
        private bool isBotTurn;

        private int playerPositiveTurnResult = 0;
        private bool playerVictory = false;
        private bool opponentVictory = false;
        private bool gameInADrow = false;
        private bool droppedCardsExist = false;

        public ApplicationViewModel()
        {
            playerDeck = new Deck();
            opponentDeck = new Deck();
            if (playerDeckCount != 1 && opponentDeckCount != 1)
            Shuffle();
            Random random = new Random();
            if (random.Next(2) == 1)
            {
                IsYourTurn = false;
                isBotTurn = true;
            }
            else
            {
                IsYourTurn = true;
                isBotTurn = false;
            }
            try
            {
                currentPlayerCard = playerDeck[0];
                currentOpponentCard = opponentDeck[0];
            }
            catch (Exception)
            {
                Card card = new Card("No cards", "", 1, 1, 1);
                playerDeck.Add(card);
                opponentDeck.Add(card);
                currentPlayerCard = playerDeck[0];
                currentOpponentCard = opponentDeck[0];
            }
            PlayerDeckCount = playerDeck.Count();
            OpponentDeckCount = opponentDeck.Count();
        }

        /// Props for UI ///
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
        public int OpponentDeckCount
        {
            get => opponentDeckCount;
            set
            {
                opponentDeckCount = value;
                OnPropertyChanged("OpponentDeckCount");
            }
        }
        public int PlayerDeckCount
        {
            get => playerDeckCount;
            set
            {
                playerDeckCount = value;
                OnPropertyChanged("PlayerDeckCount");
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
        public int PlayerPositiveTurnResult
        {
            get => playerPositiveTurnResult;
            set
            {
                playerPositiveTurnResult = value;
                OnPropertyChanged("PlayerPositiveTurnResult");
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
        public bool DroppedCardsExist{
            get => droppedCardsExist;
            set
            {
                droppedCardsExist = value;
                OnPropertyChanged("DroppedCardsExist");
            }
        }
       /// 

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
                            SelectedAttribute = Kinds.Strength;
                        else if (kind == "Stealth")
                            SelectedAttribute = Kinds.Stealth;
                        else SelectedAttribute =Kinds.Intelligence;

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
                        if (isBotTurn == true)
                        {
                            TurnResult();

                            IsYourTurn = true;
                            isBotTurn = false;
                        }
                        else
                        {
                            TurnResult();

                            SelectedAttribute = AIChoice();
                            isBotTurn = true;
                        }
                    }));
            }
        }

        private void Turn()
        {
            playerDeck.Drop();
            opponentDeck.Drop();

            if (currentPlayerCard.IsGreater(currentOpponentCard, selectedAttribute))
            {
                playerDeck.Add(currentPlayerCard);
                OpponentDeckCount--;
                DroppedCardsExist = true;
                PlayerPositiveTurnResult = 1;
            }
            else if (currentOpponentCard.IsGreater(currentPlayerCard, selectedAttribute))
            {
                Distribution();
                opponentDeck.Add(currentOpponentCard);
                PlayerDeckCount--;
                DroppedCardsExist = true;
                PlayerPositiveTurnResult = -1;
            }
            else if (currentOpponentCard == currentPlayerCard && playerDeckCount > 1 && opponentDeckCount > 1)
            {
                Random rng = new Random();
                int playerCardIndex = rng.Next(playerDeckCount);
                int opponentCardIndex;
                do opponentCardIndex = rng.Next(opponentDeckCount);
                while (opponentCardIndex == playerCardIndex);

                playerDeck.Insert(playerCardIndex, currentPlayerCard);
                opponentDeck.Insert(opponentCardIndex, currentOpponentCard);
                PlayerPositiveTurnResult = 2;
            }
            else 
            {
                playerDeck.Add(currentPlayerCard);
                opponentDeck.Add(currentOpponentCard);
                PlayerPositiveTurnResult = 2;
            }
        }

        private void TurnResult()
        {
            try
            {
                Turn();
            }
            catch (ArgumentOutOfRangeException)
            {
                if (playerDeckCount == 0) PlayerCardTitle = "No cards";
                if (opponentDeckCount == 0) OpponentCardTitle = "No cards";
            }
            try
            {
                if (playerDeckCount == 0)
                {
                    OpponentVictory = true;
                }
                else if (playerDeckCount == 1 && opponentDeckCount == 1 && playerDeck[0] == opponentDeck[0])
                {
                    NextCardAssigmentForUI();
                    GameInADraw = true;
                }
                else if (opponentDeckCount == 0)
                {
                    PlayerVictory = true;
                }
                else
                {
                    currentPlayerCard = playerDeck[0];
                    currentOpponentCard = opponentDeck[0];
                    NextCardAssigmentForUI();
                }
            }
            catch (NullReferenceException)
            {
            }
    }

        private Kinds AIChoice()
        {
            if (playerHighLevelDroppedCardsCount < playerMiddleLevelDroppedCardsCount
                && playerHighLevelDroppedCardsCount < playerLowLevelDroppedCardsCount) return currentOpponentCard.GetKindByLevel(Levels.Low);
            else if (playerMiddleLevelDroppedCardsCount < playerLowLevelDroppedCardsCount
                && playerMiddleLevelDroppedCardsCount < playerHighLevelDroppedCardsCount) return currentOpponentCard.GetKindByLevel(Levels.High);
            else if (playerLowLevelDroppedCardsCount < playerHighLevelDroppedCardsCount
                && playerLowLevelDroppedCardsCount < playerMiddleLevelDroppedCardsCount) return currentOpponentCard.GetKindByLevel(Levels.Middle);
            else return currentOpponentCard.MaxPoints();
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

        private void Distribution()
        {
            if (currentPlayerCard.Attribute(selectedAttribute).Level == Levels.High) playerHighLevelDroppedCardsCount++;
            if (currentPlayerCard.Attribute(selectedAttribute).Level == Levels.Middle) playerMiddleLevelDroppedCardsCount++;
            if (currentPlayerCard.Attribute(selectedAttribute).Level == Levels.Low) playerLowLevelDroppedCardsCount++;
        }

        private void NextCardAssigmentForUI()
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
        }
    }
}
