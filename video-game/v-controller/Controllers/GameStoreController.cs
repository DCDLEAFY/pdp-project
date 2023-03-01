using Microsoft.AspNetCore.Mvc;
using Persistence.Data;
using Domain.Models;
using Application;
using Microsoft.Identity.Client;
using Domain.Interfaces;
using WebApi.Data.Options;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    public class GameStoreController : Controller
    {

        public GamesService _gamesService;
        public ConnectionStringsOptions _connectionStringsOptions;


        public GameStoreController(GamesService gamesService, IOptions<ConnectionStringsOptions> connectionStringsOption)
        {
            _gamesService = gamesService;
            _connectionStringsOptions = connectionStringsOption.Value;
        }

        [HttpGet("get-db")]
        public async Task<IActionResult> GetDB()
        {
            return Ok(_connectionStringsOptions.DefaultConnectionString);
        }

        [HttpPost("add-game")]
        public async Task<IActionResult> AddGame([FromBody] GameQueryDto game)
        {
            _gamesService.AddGameToStore(game);
            return Ok();
        }

        [HttpGet("get-all-games")]
        public async Task<IActionResult> GetAllGames()
        {
            var allGames = _gamesService.GetAllGamesFromStore();
            return Ok(allGames);
        }

        [HttpGet("get-all-games-available")]
        public async Task<IActionResult> GetAllGamesAvailable()
        {
            var allGamesAvailable = _gamesService.GetAllAvailableGamesFromStore();
            return Ok(allGamesAvailable);
        }

        [HttpPut("update-game/{id}")]
        public async Task<IActionResult> UpdateGameById(int id, [FromBody] GameQueryDto game)
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
