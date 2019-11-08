using static EpicRandomArena.Models.Attribute;

namespace EpicRandomArena.Models
{
    public class Card
    {
        public Card(string title, string image, int stealth, int strength, int intelligence)
        {
            Title = title;
            Image = image;
            Stealth = new  Attribute(stealth, Kinds.Stealth);
            Strength = new Attribute(strength, Kinds.Strength);
            Intelligence = new Attribute(intelligence, Kinds.Intelligence);
        }

        public string Title { get; set; }

        public string Image { get; set; }

        public Attribute Stealth { get; set; }

        public Attribute Strength { get; set; }

        public Attribute Intelligence { get; set; }

        public Attribute Attribute(Kinds attributeKind)
        {
            if (attributeKind == Kinds.Strength) return Strength;
            if (attributeKind == Kinds.Stealth) return Stealth;
            else return Intelligence;
        }

        public bool IsGreater(Card other, Kinds kind)
        {
            Attribute a1 = Attribute(kind);
            Attribute a2 = other.Attribute(kind);
            if (a1.Level == a2.Level) return (a1.Points > a2.Points) ? true : false;
            else
            {
                if (a1.Level == Levels.Higth) return (a2.Level == Levels.Middle) ? true : false;
                else if (a1.Level == Levels.Middle) return (a2.Level == Levels.Low) ? true : false;
                else return (a2.Level == Levels.Higth) ? true : false;
            }
        }
    }
}
