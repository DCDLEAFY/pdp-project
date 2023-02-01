using System.Linq.Expressions;
using video_game.Data.Models;
using video_game.Data.ViewModels;

namespace video_game.Data.Services
{
    public class GamesService
    {
        private AppDbContext _context;
        
        public GamesService(AppDbContext context)
        {
            _context= context;
        }

        public void AddGame(GameVM game)
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

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(element => element.Id == id);
        }

        public Game UpdateGameById(int id, GameVM game)
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

        public Game HardDeleteGameById(int id)
        {
            var _game = GetGameById(id);
            if(_game != null)
            {
                _context.Games.Remove(_game);
                _context.SaveChanges();
                return _game;
            }

            return _game;
        }

        public Game GetGameByTitle(string title)
        {
            return _context.Games.FirstOrDefault(element => element.Title == title);
        }

        public Game SoftDeleteGameByTitle(string title)
        {
            var _game = GetGameByTitle(title);
            if(_game != null)
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
                if(game.isDeleted == true)
                {
                    games.Remove(game);
                }
            }
            return games;
        }
    }
}
