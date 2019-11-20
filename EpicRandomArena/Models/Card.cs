using System;
using System.Collections.Generic;
using static EpicRandomArena.Models.Attribute;

namespace EpicRandomArena.Models
{
    public class Card
    {
        public Card(string title, string image, int stealth, int strength, int intelligence)
        {
            Title = title;
            Image = image;
            Stealth = new Attribute(stealth, Kinds.Stealth);
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
                if (a1.Level == Levels.High) return (a2.Level == Levels.Middle) ? true : false;
                else if (a1.Level == Levels.Middle) return (a2.Level == Levels.Low) ? true : false;
                else return (a2.Level == Levels.High) ? true : false;
            }
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.Title == card2.Title);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public Kinds GetKindByLevel(Levels lvl)
        {
            Random random = new Random();
            int choice;
            if (Intelligence.Level == lvl && Stealth.Level == lvl && Strength.Level == lvl)
            {
                if (Intelligence.Points > Stealth.Points && Intelligence.Points > Strength.Points) return Kinds.Intelligence;
                else if (Stealth.Points > Intelligence.Points && Stealth.Points > Strength.Points) return Kinds.Stealth;
                else if (Strength.Points > Intelligence.Points && Strength.Points > Stealth.Points) return Kinds.Strength;
                else if (Intelligence.Points > Stealth.Points && Intelligence.Points == Strength.Points)
                {
                    choice = random.Next(0, 1);
                    if (choice == 0) return Kinds.Intelligence;
                    if (choice == 1) return Kinds.Strength;
                }
                else if (Stealth.Points > Intelligence.Points && Stealth.Points == Strength.Points)
                {
                    choice = random.Next(0, 1);
                    if (choice == 0) return Kinds.Stealth;
                    if (choice == 1) return Kinds.Strength;
                }
                else if (Stealth.Points == Intelligence.Points && Stealth.Points > Strength.Points)
                {
                    choice = random.Next(0, 1);
                    if (choice == 0) return Kinds.Intelligence;
                    if (choice == 1) return Kinds.Stealth;
                }
                else
                {
                    choice = random.Next(0, 2);
                    if (choice == 0) return Kinds.Intelligence;
                    else if (choice == 1) return Kinds.Stealth;
                    else return Kinds.Strength;
                }
            }
            else if (Intelligence.Level == lvl && Stealth.Level == lvl)
            {
                if (Intelligence.Points > Stealth.Points) return Kinds.Intelligence;
                else if (Stealth.Points > Intelligence.Points) return Kinds.Stealth;
                else
                {
                    choice = random.Next(0, 1);
                    if (choice == 0) return Kinds.Intelligence;
                    if (choice == 1) return Kinds.Stealth;
                }
            }
            else if (Strength.Level == lvl && Stealth.Level == lvl)
            {
                if (Stealth.Points > Strength.Points) return Kinds.Stealth;
                else if (Strength.Points > Stealth.Points) return Kinds.Strength;
                else
                {
                    choice = random.Next(0, 1);
                    if (choice == 0) return Kinds.Strength;
                    if (choice == 1) return Kinds.Stealth;
                }
            }
            else if (Intelligence.Level == lvl && Strength.Level == lvl)
            {
                if (Intelligence.Points > Strength.Points) return Kinds.Intelligence;
                else if (Strength.Points > Intelligence.Points) return Kinds.Strength;
                else
                {
                    choice = random.Next(0, 1);
                    if (choice == 0) return Kinds.Intelligence;
                    if (choice == 1) return Kinds.Strength;
                }
            }
            else if (Intelligence.Level == lvl) return Kinds.Intelligence;
            else if (Stealth.Level == lvl) return Kinds.Stealth;
            return Kinds.Strength;
        }

        public Kinds MaxPoints()
        {
            Random random = new Random();
            int choice;
            if (Diff(Intelligence) < Diff(Stealth) && Diff(Intelligence) < Diff(Strength)) return Kinds.Intelligence;
            else if (Diff(Stealth) < Diff(Intelligence) && Diff(Stealth) < Diff(Strength)) return Kinds.Stealth;
            else if (Diff(Strength) < Diff(Intelligence) && Diff(Strength) < Diff(Stealth)) return Kinds.Strength;
            else if (Diff(Intelligence) == Diff(Stealth) && Diff(Intelligence) < Diff(Strength))
            {
                choice = random.Next(0, 1);
                if (choice == 0) return Kinds.Intelligence;
                if (choice == 1) return Kinds.Stealth;
            }
            else if (Diff(Stealth) == Diff(Strength) && Diff(Stealth) < Diff(Intelligence))
            {
                choice = random.Next(0, 1);
                if (choice == 0) return Kinds.Strength;
                if (choice == 1) return Kinds.Stealth;
            }
            else if (Diff(Strength) == Diff(Intelligence) && Diff(Strength) < Diff(Stealth))
            {
                choice = random.Next(0, 1);
                if (choice == 0) return Kinds.Intelligence;
                if (choice == 1) return Kinds.Strength;
            }
            else
            {
                choice = random.Next(0, 2);
                if (choice == 0) return Kinds.Intelligence;
                else if (choice == 1) return Kinds.Stealth;
                else return Kinds.Strength;
            }
            return Kinds.Stealth;
        }

        private int Diff(Attribute attribute)
        {
            if (attribute.Level == Levels.High) return 15 - attribute.Points;
            else if (attribute.Level == Levels.Middle) return 10 - attribute.Points;
            else return 5 - attribute.Points;
        }

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Title == card.Title &&
                   Image == card.Image &&
                   EqualityComparer<Attribute>.Default.Equals(Stealth, card.Stealth) &&
                   EqualityComparer<Attribute>.Default.Equals(Strength, card.Strength) &&
                   EqualityComparer<Attribute>.Default.Equals(Intelligence, card.Intelligence);
        }

        public override int GetHashCode()
        {
            var hashCode = -1849085919;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<Attribute>.Default.GetHashCode(Stealth);
            hashCode = hashCode * -1521134295 + EqualityComparer<Attribute>.Default.GetHashCode(Strength);
            hashCode = hashCode * -1521134295 + EqualityComparer<Attribute>.Default.GetHashCode(Intelligence);
            return hashCode;
        }
    }
}
