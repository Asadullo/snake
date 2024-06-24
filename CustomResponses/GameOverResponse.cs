using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Snake.CustomResponses
{
    public class GameOverResponse : ObjectResult
    {
        public GameOverResponse(object value) : base(value)
        {
            StatusCode = 418; 
        }
    }
}