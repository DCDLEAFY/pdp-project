using Microsoft.AspNetCore.Mvc;
using v_repository.Data.Dto;
using v_service;

namespace v_controller.Controllers
{
    public class GameStoreController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class GamesController : ControllerBase
        {
            public GamesService _gamesService;

            public GamesController(GamesService gamesService)
            {
                _gamesService = gamesService;
            }

            [HttpPost("add-game")]
            public IActionResult AddGame([FromBody] GameQueryDto game)
            {
                _gamesService.AddGameToStore(game);
                return Ok();
            }

            [HttpGet("get-all-games")]
            public IActionResult GetAllGames()
            {
                var allGames = _gamesService.GetAllGamesFromStore();
                return Ok(allGames);
            }

            [HttpGet("get-all-games-available")]
            public IActionResult GetAllGamesAvailable()
            {
                var allGamesAvailable = _gamesService.GetAllAvailableGamesFromStore();
                return Ok(allGamesAvailable);
            }


            [HttpGet("get-game-by-title/{title}")]
            public IActionResult GetGameById(string title)
            {
                var game = _gamesService.GetGameFromStoreByTitle(title);
                if (game == null)
                {
                    return BadRequest();
                }
                return Ok(game);
            }

            [HttpPut("update-game/{id}")]
            public IActionResult UpdateGameById(int id, [FromBody] GameQueryDto game)
            {
                var updatedGame = _gamesService.UpdateGameFromStoreById(id, game);
                if (updatedGame == null)
                {
                    return BadRequest();
                }
                return Ok(updatedGame);
            }
        }
    }
}
