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
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(int id);
        Task<GameQueryDto> Add(GameQueryDto record);
        Task<Game> DeleteById(int id);
        Task SaveChanges();
    }
}
