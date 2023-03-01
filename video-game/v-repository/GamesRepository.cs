using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class GamesRepository : IRepository
    {
        public AppDbContext _context;

        public GamesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GameQueryDto> Add(GameQueryDto record)
        {
            var newRecord = new Game()
            {
                Title = record.Title,
                Description = record.Description,
                Genre = record.Genre,
                RRP = record.RRP,
                ImagePath = record.ImagePath,
                isDeleted = record.isDeleted
            };
            await _context.Games.AddAsync(newRecord);

            return record;
        }

        public async Task<Game> DeleteById(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (game != null)
            {
                _context.Remove(game);
                return game;
            }

            return null;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _context.Games.Include(a => a.Id)
                                        .Include(a => a.RRP)
                                        .Include(a => a.Genre)
                                        .Include(a => a.Description)
                                        .Include(a => a.isDeleted)
                                        .ToListAsync();
        }

        public async Task<Game> GetById(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
