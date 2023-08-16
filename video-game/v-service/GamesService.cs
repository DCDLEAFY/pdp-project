using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Persistence.Data;
using Domain.Models;
using Domain.Interfaces;

namespace Application
{
	public class GamesService : IService
	{
		public IRepository _gamesRepository;
		

		public GamesService(IRepository gameRepository)
		{
			_gamesRepository = gameRepository;
        }

		public async void AddGameToStore(GameQueryDto game)
		{
            Game addGame = new Game()
            {
                Title = game.Title,
                isDeleted = game.isDeleted,
                Description = game.Description,
                RRP = game.RRP,
                Genre = game.Genre,
				ImagePath = game.ImagePath,
            };

            await _gamesRepository.Add(addGame);
		}

		public async Task<Game> UpdateGameFromStoreById(int id, GameQueryDto game)
		{
			Game updatedGame = new Game()
			{
				Title = game.Title,
				isDeleted = game.isDeleted,
				Description = game.Description,
				RRP = game.RRP,
				Genre = game.Genre
			};

			return await _gamesRepository.UpdateGameFromStoreById(id, updatedGame);
        }

		public async Task<IEnumerable<Game>> GetGamesByTitle(string title)
		{
			return await _gamesRepository.GetGamesByTitle(title);
		}

		public async Task<IEnumerable<Game>> RemoveGameFromStoreByTitle(string title)
		{
			return await _gamesRepository.GetGamesByTitle(title);
		}

        public Task<IEnumerable<Game>> GetAllGame()
		{
			return _gamesRepository.GetAll();
		}
    }
}
