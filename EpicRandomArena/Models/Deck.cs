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

        public Deck()
        {
            cards = new ObservableCollection<Card>();
        }

        public int Count() => cards.Count();

        public void Remove(Card card) => cards.Remove(card);

        public void Add(Card card) => cards.Add(card);

        
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)cards).GetEnumerator();
        }

        public Card this[int i]
        {
            get => cards[i];
            set => cards[i] = value;
        }
    }
}
