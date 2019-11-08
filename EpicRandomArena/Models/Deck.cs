using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            //Random shuffle
        }

        public int Count() => cards.Count();

        public void Drop() => cards.RemoveAt(0);

        public void Add(Card card) => cards.Add(card);

        public void RandomShove(Card card)
        {

        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)cards).GetEnumerator();
        }

    }
}
