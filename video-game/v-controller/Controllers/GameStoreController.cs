using Microsoft.AspNetCore.Mvc;
using Persistence.Data;
using Domain.Models;
using Application;
using Microsoft.Identity.Client;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    public class GameStoreController : Controller
    {

        public IGameService _gamesService;


        public GameStoreController(IGameService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpPost("add-game")]
        public async Task<IActionResult> AddGame([FromBody] GameDto game)
        {
            _gamesService.AddGameToStore(game);
            return Ok(game);
        }

        [HttpPut("update-game/{id}")]
        public async Task<IActionResult> UpdateGameById(int id, [FromBody] GameDto game)
        {
            var updatedGame = _gamesService.UpdateGameFromStoreById(id, game);

            if(updatedGame.Result != null)
            {
                return Ok(updatedGame);
            }
            return BadRequest("Supplied Game body or Id is incorrect");
        }

        [HttpGet("get-games-by-title/{title}")]
        public async Task<IActionResult> GetGameByTitle(string title)
        {
            var games = _gamesService.GetGamesByTitle(title);
            if(games.Result.Any())
            {
                return Ok(games);
            }

            return NotFound("No games with supplied title found");
        }

        [HttpPut("delete-games-by-title/{title}")]
        public async Task<IActionResult> DeleteGameByTitle(string title)
        {
            var games = _gamesService.RemoveGameFromStoreByTitle(title);
            return Ok(games);


        }

        [HttpGet("testing-getall")]
        public async Task<IActionResult> GetAll()
        {
            var allGames= await _gamesService.GetAllGame();
            Console.WriteLine(allGames.ToString());
            return Ok(allGames);
        }

    }
}
