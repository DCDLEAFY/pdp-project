using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v_repository;
using v_repository.Data;
using v_repository.Data.Dto;
using v_repository.Data.Models;

namespace v_service
{
	public class GamesService
	{
		private readonly GamesRepository _gamesRepository;

		public GamesService(AppDbContext appDbContext)
		{
			_gamesRepository= new GamesRepository(appDbContext);
		}

		public void AddGameToStore(GameQueryDto game)
		{
			_gamesRepository.AddGame(game);
		}

		public Game? UpdateGameFromStoreById(int id, GameQueryDto game)
		{
			return _gamesRepository.UpdateGameById(id, game);
		}

		public List<Game> GetAllGamesFromStore()
		{
			return _gamesRepository.GetAllGames();
		}

		public List<Game> GetAllAvailableGamesFromStore() 
		{
			return _gamesRepository.GetAllGamesAvailable();
		}

		public Game? RemoveGameFromStoreByTitle(string title)
		{
			return _gamesRepository.SoftDeleteGameByTitle(title);
		}

		public Game? GetGameFromStoreByTitle(string title)
		{
			return _gamesRepository.GetGameByTitle(title);
		}
    }
}
