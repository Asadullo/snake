namespace Snake.Models
{
    public class Snake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }

        public Snake() 
        {
            VelX = 1;
        }
    }
}
