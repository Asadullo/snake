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
                Fruit = new Models.Fruit(width,height),
                Snake = new Models.Snake()
            };
        }

        public int ValidateFullGame(FullGame fullGame) 
        {
            int result = _play(fullGame);
            if (result == 1)
            {
                fullGame.State.Score++;
                fullGame.State.Fruit = new Fruit(fullGame.State.Width, fullGame.State.Height);
            }
            return result;
        }

        //TODO: move return results to Enum for better readability
        
        private int _play(FullGame fullGame)
        {
            Snake.Models.Snake snake = fullGame.State.Snake;
            Snake.Models.Fruit fruit = fullGame.State.Fruit;

            foreach (Tick tick in fullGame.Ticks) 
            {
                //TODO: Detect invalid moves

                if (tick.VelX == 1) snake.X++;
                else if(tick.VelX == -1) snake.X--;

                //Snake reach the boundaries
                if (snake.X == fullGame.State.Width || snake.X<0) return -2;

                if (tick.VelY == 1) snake.Y++;
                else if (tick.VelY == -1) snake.Y--;

                //Snake reach the boundaries
                if (snake.Y == fullGame.State.Height || snake.Y < 0) return -2;

            }

            if(snake.X == fruit.X && snake.Y == fruit.Y)
                return 1;

            //Fruit not found
            return -1;

        }
    }
}
