
namespace EpicRandomArena.Models
{
    public class Card
    {
        public Card(string title, string image, Attribute stealth, Attribute strength, Attribute intelligence)
        {
            Title = title;
            Image = image;
            Stealth = stealth;
            Strength = strength;
            Intelligence = intelligence;
        }

        public string Title { get; }

        public string Image { get; }

        public Attribute Stealth { get; }

        public Attribute Strength { get; }

        public Attribute Intelligence { get; }
    }
}
