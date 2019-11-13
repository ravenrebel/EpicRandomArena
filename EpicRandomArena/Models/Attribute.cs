using System;

namespace EpicRandomArena.Models
{
    public class Attribute
    {
        public Attribute(int points, Kinds kind)
        {
            Points = points;
            Kind = kind;
            if (points < 1 || points > 15) throw new Exception("Invalid number of points.");
            else
            {
                if (points <= 5) Level = Levels.Low;
                else if (points >= 6 && points <= 10) Level = Levels.Middle;
                else Level = Levels.High;
            }
        }

       public Kinds Kind { get; }

        public Levels Level { get; set; }

        public int Points { get; set; }

        public enum Levels
        {
            Low,
            Middle,
            High
        }

        public enum Kinds
        {
            Stealth,
            Strength,
            Intelligence
        }
    }
}
