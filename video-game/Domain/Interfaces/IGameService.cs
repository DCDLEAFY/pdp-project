using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGameService
    {
        void AddGameToStore(GameDto game);
        Task<Game> UpdateGameFromStoreById(int id, GameDto game);
        Task<IEnumerable<Game>> RemoveGameFromStoreByTitle(string title);
        Task<IEnumerable<Game>> GetGamesByTitle(string title);
        Task<IEnumerable<Game>> GetAllGame();
    }
}
