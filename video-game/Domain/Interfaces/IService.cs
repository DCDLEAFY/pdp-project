using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IService
    {
        void AddGameToStore(GameQueryDto game);
        Task<Game> UpdateGameFromStoreById(int id, GameQueryDto game);
        Task<IEnumerable<Game>> RemoveGameFromStoreByTitle(string title);
        Task<IEnumerable<Game>> GetGamesByTitle(string title);
        Task<IEnumerable<Game>> GetAllGame();
    }
}
