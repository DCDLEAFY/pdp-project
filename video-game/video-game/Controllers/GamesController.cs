using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using video_game.Data.Models;
using video_game.Data.Services;
using video_game.Data.ViewModels;

namespace video_game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public GamesService _gamesService;

        public GamesController(GamesService gamesService)
        {
            _gamesService= gamesService;
        }

        [HttpPost("add-game")]
        public IActionResult AddGame([FromBody]GameVM game)
        {
            _gamesService.AddGame(game);
            return Ok();
        }

        [HttpGet("get-all-games")]
        public IActionResult GetAllGames()
        {
            var allGames = _gamesService.GetAllGames();
            return Ok(allGames);
        }

        [HttpGet("get-game-by-id/{id}")]
        public IActionResult GetGameById(int id)
        {
            var game = _gamesService.GetGameById(id);
            if (game == null)
            {
                return BadRequest();
            }
            return Ok(game);
        }

        [HttpPut("update-game/{id}")]
        public IActionResult UpdateGameById(int id, [FromBody]GameVM game)
        {
            var updatedGame = _gamesService.UpdateGameById(id, game);
            if (updatedGame == null)
            {
                return BadRequest();
            }
            return Ok(updatedGame);
        }

        [HttpDelete("delete-game-by-id/{id}")]
        public IActionResult DeleteGameById(int id)
        {
            var deletedGame = _gamesService.DeleteGameById(id);
            if (deletedGame == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
} 