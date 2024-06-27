using Snake.Models;

namespace Snake.Services
{
    public class GameService: IGameService
    {
        private HashSet<int> _allowedVelocityValues = new HashSet<int>() { 1, 0, -1 };
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
            int result = 0;

            //Detect invalid moves. return code -3
            //Velocity is out of allowed values
            fullGame.Ticks.ForEach(t => { if (!_allowedVelocityValues.Contains(t.VelX) || !_allowedVelocityValues.Contains(t.VelY)) result = -3; return; });
            if (result == -3) return result;    
                
            result = _play(fullGame);

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

            Tick previousTick = null;

            foreach (Tick currentTick in fullGame.Ticks) 
            {
                //Detect invalid moves. return code -3                
                if (previousTick != null)
                {
                    //impossible for it to do an immediate 180-degree turn
                    if (previousTick.VelX == 1 && currentTick.VelX == -1) return -3;
                    if (previousTick.VelY == 1 && previousTick.VelY == -1) return -3;
                }

                //can move only to a single direction on single axis
                if ((currentTick.VelX == 1 || currentTick.VelX == -1) && currentTick.VelY != 0) return -3;
                if ((currentTick.VelY == 1 || currentTick.VelY == -1) && currentTick.VelX != 0) return -3;

                if (currentTick.VelX == 1) snake.X++;
                else if(currentTick.VelX == -1) snake.X--;

                //Snake reach the boundaries
                if (snake.X == fullGame.State.Width || snake.X<0) return -2;

                if (currentTick.VelY == 1) snake.Y++;
                else if (currentTick.VelY == -1) snake.Y--;

                //Snake reach the boundaries
                if (snake.Y == fullGame.State.Height || snake.Y < 0) return -2;

                previousTick = currentTick;
            }

            if(snake.X == fruit.X && snake.Y == fruit.Y)
                return 1;

            //Fruit not found
            return -1;

        }
    }
}
