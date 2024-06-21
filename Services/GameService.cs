using Snake.Models;

namespace Snake.Services
{
    public class GameService: IGameService
    {
        public State StartNewGame(int width, int height)
        {
            return new State
            {
                GameID = Guid.NewGuid().ToString(),
                Width = width,
                Height = height,
                Score = 0,
                Fruit = new Models.Fruit { X = new Random().Next(width), Y = new Random().Next(height) },
                Snake = new Models.Snake { X = 0, Y = 0, VelX = 1, VelY = 0 }
            };
        }
    }
}
