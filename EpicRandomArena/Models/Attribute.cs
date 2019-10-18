using System;

namespace EpicRandomArena.Models
{
    public class Attribute
    {
        public Attribute(int points)
        {
            Points = points;
            if (points < 1 || points > 15) throw new Exception("Invalid number of points.");
            else
            {
                if (points <= 5) Level = Levels.Low;
                else if (points >= 6 && points <= 10) Level = Levels.Middle;
                else Level = Levels.Higth;
            }
        }

        public Levels Level { get; }

        public int Points { get; }

        public enum Levels
        {
            Low,
            Middle,
            Higth
        }
    }
}
