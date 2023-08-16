using Microsoft.AspNetCore.Mvc;
using Persistence.Data;
using Domain.Models;
using Application;
using Microsoft.Identity.Client;
using Domain.Interfaces;
using MediatR;
using Application.Mediatr.Request;

namespace WebApi.Controllers
{
    public class GameStoreController : Controller
    {

        public IGameService _gamesService;
        public IMediator _mediator;


        public GameStoreController(IGameService gamesService, IMediator Mediator)
        {
            _gamesService = gamesService;
            _mediator = Mediator;
        }

        [HttpPost("add-game")]
        public async Task<IActionResult> AddGame([FromBody] GameDto game)
        {
            var result = await _mediator.Send(new AddGameRequest(game));

            if(!result.IsSuccesful)
            {
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpPut("update-game/{id}")]
        public async Task<IActionResult> UpdateGameById(int id, [FromBody] GameDto game)
        {

            var result = await _mediator.Send(new UpdateGameRequest(id ,game));

            if(!result.IsSuccesful)
            {
                return StatusCode(500);
            }

            return Ok(result);
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
