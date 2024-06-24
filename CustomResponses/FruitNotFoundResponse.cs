using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Snake.CustomResponses
{
    public class FruitNotFoundResponse : ObjectResult
    {
        public FruitNotFoundResponse(object value) : base(value)
        {
            StatusCode = 404;            
        }
    }
}