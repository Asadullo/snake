using Microsoft.AspNetCore.Mvc;
using Snake.CustomResponses;
using Snake.Models;
using Snake.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Snake.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SnakeGameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public SnakeGameController(IGameService gameService)
        { 
            _gameService = gameService;
        }


        [HttpGet]
        [Route("new")]
        public IActionResult New([FromQuery] int? w, [FromQuery] int? h)
        {
            try
            {
                int width = 0;
                int height = 0;
                if (!int.TryParse(w.ToString(), out width) || !int.TryParse(h.ToString(), out height))
                {
                    return BadRequest();
                }
                string response = JsonSerializer.Serialize(_gameService.StartNewGame(width, height), new JsonSerializerOptions { WriteIndented = true });
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("validate")]
        [ProducesResponseType(typeof(FullGame), 200)]
        [ProducesResponseType(typeof(State),404)]
        [ProducesResponseType(418)]
        public IActionResult validate([FromBody] FullGame fullGame)
        {
            
            try
            {
                int result = _gameService.ValidateFullGame(fullGame);

                if (result == 1) return Ok(fullGame.State);
                else if (result == -1) return new FruitNotFoundResponse(
                    new
                    {
                        message =
                        JsonSerializer.Serialize(_gameService.StartNewGame(fullGame.State.Width, fullGame.State.Height), new JsonSerializerOptions { WriteIndented = true })
                    }
                 );
                else if (result == -2) return new GameOverResponse(
                    new
                    {
                        message = fullGame.State.Score                        
                    }
                );
                else return BadRequest();
            }
            catch (Exception ex) { return BadRequest(); }
            
        }
    }
}
