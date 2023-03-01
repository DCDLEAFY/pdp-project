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
	public class GamesService
	{
		public IRepository _gamesRepository;

		public GamesService(IRepository gameRepository)
		{
			_gamesRepository = gameRepository;
        }

		public async void AddGameToStore(GameQueryDto game)
		{
			await _gamesRepository.Add(game);
			await _gamesRepository.SaveChanges();
		}

		public async Task<Game> UpdateGameFromStoreById(int id, GameQueryDto game)
		{
			if (_gamesRepository.GetById(id) == null) return null;

            _gamesRepository.GetById(id).Result.Title = game.Title;
            _gamesRepository.GetById(id).Result.Description = game.Description;
            _gamesRepository.GetById(id).Result.RRP = game.RRP;
            _gamesRepository.GetById(id).Result.isDeleted = game.isDeleted;
            _gamesRepository.GetById(id).Result.Genre = game.Genre;
            _gamesRepository.GetById(id).Result.ImagePath = game.ImagePath;

			await _gamesRepository.SaveChanges();

			return _gamesRepository.GetById(id).Result;

        }

		public async Task<IEnumerable<Game>> GetAllGamesFromStore()
		{
			return _gamesRepository.GetAll().Result;
		}

		public async Task<IEnumerable<Game>> GetAllAvailableGamesFromStore() 
		{
			//Not too sure about this
			return _gamesRepository.GetAll().Result.Where(X => X.isDeleted == false);
		}

		public async Task<Game> RemoveGameFromStoreByTitle(string title)
		{
			var result = _gamesRepository.GetAll().Result.FirstOrDefault(x => x.Title == title);

            if ( result == null) return null;

			result.isDeleted = true;
			
			await _gamesRepository.SaveChanges();

			return result;
		}
    }
}
