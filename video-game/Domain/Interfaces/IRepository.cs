using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        Task<Game> GetById(int id);
        Task<Game> Add(Game record);
        Task<Game> DeleteById(int id);
        Task<IEnumerable<Game>> GetGamesByTitle(string title);
        Task SaveChanges();
        Task<IEnumerable<Game>> GetAll();
        Task<Game> UpdateGameFromStoreById(int id, Game updatedGame);
    }
}
