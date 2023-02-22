using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v_repository.Data;
using v_repository.Data.Models;
using v_repository.Data.Dto;


namespace v_repository
{
    public class GamesRepository
    {
        private AppDbContext _context;

        public GamesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddGame(GameQueryDto game)
        {
            var _game = new Game()
            {
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                RRP = game.RRP,
                ImagePath = game.ImagePath,
                isDeleted = game.isDeleted
            };

            _context.Add(_game);
            _context.SaveChanges();
        }

        public List<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public Game? GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(element => element.Id == id);
        }

        public Game? UpdateGameById(int id, GameQueryDto game)
        {
            var _game = GetGameById(id);
            if (_game != null)
            {
                _game.Title = game.Title;
                _game.Description = game.Description;
                _game.Genre = game.Genre;
                _game.RRP = game.RRP;
                _game.ImagePath = game.ImagePath;
                _game.isDeleted = game.isDeleted;

                _context.SaveChanges();
            }
            return _game;
        }

        public Game? GetGameByTitle(string title)
        {
            return _context.Games.FirstOrDefault(element => element.Title == title);
        }

        public Game? SoftDeleteGameByTitle(string title)
        {
            var _game = GetGameByTitle(title);
            if (_game != null)
            {
                _game.isDeleted = true;

                _context.SaveChanges();
                return _game;
            }

            return _game;
        }
        public List<Game> GetAllGamesAvailable()
        {
            List<Game> games = _context.Games.ToList();
            foreach (var game in games.ToList())
            {
                if (game.isDeleted == true)
                {
                    games.Remove(game);
                }
            }
            return games;
        }
    }
}
