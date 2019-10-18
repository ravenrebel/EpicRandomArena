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
    public class ApplicationViewModel
    {
        private Card card;

        public ApplicationViewModel()
        {
            Deck deck = new Deck();
            deck.Add(new Card("Ilona",
                "path",
                new Models.Attribute(9),
                new Models.Attribute(4),
                new Models.Attribute(12)));
            card = deck[0];
        }

        public string Title => card.Title;

        public string Image=> card.Image;

        public string IntelligencePoints => card.Intelligence.Points.ToString();

        public string StealthPoints => card.Stealth.Points.ToString();

        public string StrengthPoints => card.Strength.Points.ToString();

        // color that indicate lvl of attribute->func?
    }
}
