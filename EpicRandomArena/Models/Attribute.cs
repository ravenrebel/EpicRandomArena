using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Attribute attribute &&
                   Kind == attribute.Kind &&
                   Level == attribute.Level &&
                   Points == attribute.Points;
        }

        public override int GetHashCode()
        {
            var hashCode = -1012777218;
            hashCode = hashCode * -1521134295 + Kind.GetHashCode();
            hashCode = hashCode * -1521134295 + Level.GetHashCode();
            hashCode = hashCode * -1521134295 + Points.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Attribute left, Attribute right)
        {
            return EqualityComparer<Attribute>.Default.Equals(left, right);
        }

        public static bool operator !=(Attribute left, Attribute right)
        {
            return !(left == right);
        }

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
