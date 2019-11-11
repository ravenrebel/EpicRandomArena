using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EpicRandomArena.Models
{
    public class Deck : IEnumerable
    {
        private ObservableCollection<Card> cards;

        public Card TopCard => cards[0];

        public Deck()
        {
            cards = new ObservableCollection<Card>();
            cards.Add(new Card("Ilona", "/EpicRandomArena;component/Graphics/Ilona.png", 9, 4, 11));
            cards.Add(new Card("Anastasia", "/EpicRandomArena;component/Graphics/Ilona.png", 7, 1, 12));
            cards.Add(new Card("Tony Stark", "/EpicRandomArena;component/Graphics/Ilona.png", 13, 5, 15));
            cards.Add(new Card("Batman", "/EpicRandomArena;component/Graphics/Ilona.png", 12, 10, 6));
            cards.Add(new Card("Darth Vader", "/EpicRandomArena;component/Graphics/Ilona.png", 4, 14, 2));
            cards.Add(new Card("Arthas", "/EpicRandomArena;component/Graphics/Ilona.png", 8, 13, 8));
            cards.Add(new Card("Arthas", "/EpicRandomArena;component/Graphics/Ilona.png", 8, 13, 8));
            cards.Add(new Card("Pudge", "/EpicRandomArena;component/Graphics/Ilona.png", 2, 12, 1));
            cards.Add(new Card("Invoker", "/EpicRandomArena;component/Graphics/Ilona.png", 13, 3, 14));
            cards.Add(new Card("Valentin", "/EpicRandomArena;component/Graphics/Ilona.png", 15, 9, 6));
            cards.Add(new Card("Thor", "/EpicRandomArena;component/Graphics/Ilona.png", 4, 14, 5));
            cards.Add(new Card("Geralt of Rivia", "/EpicRandomArena;component/Graphics/Ilona.png", 10, 10, 9));
            cards.Add(new Card("Saitama", "/EpicRandomArena;component/Graphics/Ilona.png", 3, 15, 4));
            cards.Add(new Card("Geralt of Rivia", "/EpicRandomArena;component/Graphics/Ilona.png", 10, 10, 9));
            cards.Add(new Card("Elon Mask", "/EpicRandomArena;component/Graphics/Ilona.png", 10, 6, 14));
            cards.Add(new Card("Volodia", "/EpicRandomArena;component/Graphics/Ilona.png", 11, 7, 10));
            cards.Add(new Card("Olia", "/EpicRandomArena;component/Graphics/Ilona.png", 6, 3, 11));
            cards.Add(new Card("Diakoniuk", "/EpicRandomArena;component/Graphics/Ilona.png", 5, 4, 13));
            cards.Add(new Card("Iashchuk Xandrovich", "/EpicRandomArena;component/Graphics/Ilona.png", 7, 5, 13));
            cards.Add(new Card("Loki", "/EpicRandomArena;component/Graphics/Ilona.png", 14, 4, 8));
            cards.Add(new Card("Hapko", "/EpicRandomArena;component/Graphics/Ilona.png", 9, 2, 13));
            cards.Add(new Card("Half of Truhan", "/EpicRandomArena;component/Graphics/Ilona.png", 1, 3, 8));
            Shuffle();
        }

        // Fisher–Yates shuffle
        private void Shuffle()
        {
            Random rng = new Random();
            int n = Count();
            while (n > 1)
             {
                int k = rng.Next(n + 1);
                n--;
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
             }
        }

        public int Count() => cards.Count();

        public void Drop() => cards.RemoveAt(0);

        public void Add(Card card) => cards.Add(card);

        public void RandomShove(Card card)
        {
            Random random = new Random();
            cards.Insert(random.Next(0, Count()), card);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)cards).GetEnumerator();
        }

    }
}
