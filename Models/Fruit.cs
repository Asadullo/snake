namespace Snake.Models
{
    public class Fruit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Fruit() { }
        public Fruit(int width, int height)
        {
            X = new Random().Next(width);
            Y = new Random().Next(height);
        }
    }
}
