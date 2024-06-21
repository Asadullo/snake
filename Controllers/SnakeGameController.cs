using Microsoft.AspNetCore.Mvc;
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


        // GET api/<ValuesController>/5
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

        // POST api/<ValuesController>
        [HttpPost]
        [Route("validate")]
        public IActionResult validate([FromBody] string value)
        {
            return Ok(value);
        }
    }
}
