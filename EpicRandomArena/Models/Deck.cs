using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EpicRandomArena.Models
{
    public class Deck
    {
        private ObservableCollection<Card> cards;

        public Deck()
        {
            cards = new ObservableCollection<Card>();
            cards.Add(new Card("Ilona", "/EpicRandomArena;component/Graphics/CardFolder/Ilona.png", 9, 4, 11));
            cards.Add(new Card("Anastasia", "/EpicRandomArena;component/Graphics/CardFolder/nastya.jpg", 9, 1, 12));
            cards.Add(new Card("Tony Stark", "/EpicRandomArena;component/Graphics/CardFolder/tony_stark.jpg", 11, 5, 15));
            cards.Add(new Card("Batman", "/EpicRandomArena;component/Graphics/CardFolder/batman.jpg", 12, 10, 6));
            //cards.Add(new Card("Darth Vader", "/EpicRandomArena;component/Graphics/CardFolder/darth_vader.jpg", 4, 14, 2));
            //cards.Add(new Card("Arthas", "/EpicRandomArena;component/Graphics/CardFolder/arthas.jpg", 8, 13, 7));
            //cards.Add(new Card("Pudge", "/EpicRandomArena;component/Graphics/CardFolder/pudge.jpg", 2, 12, 1));
            //cards.Add(new Card("Invoker", "/EpicRandomArena;component/Graphics/CardFolder/invoker.jpg", 13, 3, 14));
            //cards.Add(new Card("Valentin", "/EpicRandomArena;component/Graphics/CardFolder/valik.JPG", 15, 9, 6));
            //cards.Add(new Card("Thor", "/EpicRandomArena;component/Graphics/CardFolder/thor.jpg", 4, 13, 5));
            //cards.Add(new Card("Geralt of Rivia", "/EpicRandomArena;component/Graphics/CardFolder/geralt.jpg", 10, 10, 9));
            //cards.Add(new Card("Saitama", "/EpicRandomArena;component/Graphics/CardFolder/saitama.gif", 3, 15, 4));
            //cards.Add(new Card("Elon Mask", "/EpicRandomArena;component/Graphics/CardFolder/elon_mask.jpg", 10, 6, 14));
            //cards.Add(new Card("Volodia", "/EpicRandomArena;component/Graphics/CardFolder/volodia.JPG", 11, 7, 10));
            //cards.Add(new Card("Olia", "/EpicRandomArena;component/Graphics/CardFolder/olya.jpg", 6, 3, 11));
            //cards.Add(new Card("Diakoniuk", "/EpicRandomArena;component/Graphics/CardFolder/dyiakonuk.jpg", 5, 4, 13));
            //cards.Add(new Card("Iashchuk Xandrovich", "/EpicRandomArena;component/Graphics/CardFolder/Ilona.png", 7, 5, 13));
            //cards.Add(new Card("Loki", "/EpicRandomArena;component/Graphics/CardFolder/loki.jpg", 14, 4, 8));
            //cards.Add(new Card("Hapko", "/EpicRandomArena;component/Graphics/CardFolder/hapko.png", 7, 2, 13));
            //cards.Add(new Card("Half of Truhan", "/EpicRandomArena;component/Graphics/CardFolder/Ilona.png", 1, 4, 8));
        }

        public int Count() => cards.Count();

        public void Drop() => cards.RemoveAt(0);

        public void Add(Card card) => cards.Add(card);

        public void Insert(int index, Card card) => cards.Insert(index, card);

        public Card this[int i] 
        {
            get => cards[i];
            set => cards[i] = value;
        }
    }
}
