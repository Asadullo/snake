namespace Snake.Models
{
    public class State
    {
        public string GameID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Score { get; set; }
        public Fruit Fruit { get; set; }
        public Snake Snake { get; set; }

    }
}
