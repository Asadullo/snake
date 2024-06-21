using Snake.Models;

namespace Snake.Services
{
    public interface IGameService
    {
        public State StartNewGame(int width, int height);
    }
}
