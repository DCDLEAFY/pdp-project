using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<Game> Add(Game record)
        {
            await _context.Games.AddAsync(record);

            await SaveChanges();

            return record;
        }

        public async Task<Game> DeleteById(int id)
        {
            var game = await GetById(id);
            if (game == null) return game;

            _context.Remove(game);

            await SaveChanges();

            return game;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesByTitle(string title)
        {
            return await _context.Games.Where(x => x.Title == title).ToListAsync();
        }

        public async Task<Game> GetById(int id)
        {
            return await _context.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Game> DeleteByTitle(string title)
        {
            var deletedGame = await GetGamesByTitle(title);

            if (!deletedGame.Any()) return deletedGame.FirstOrDefault();

            deletedGame.First().isDeleted = true;

            await SaveChanges();

            return deletedGame.First();
        }

        public async Task<Game> UpdateGameFromStoreById(int id, Game updatedGame)
        {
            var gameToUpdate = await GetById(id);

            if (gameToUpdate == null) return gameToUpdate;

            gameToUpdate.Title = updatedGame.Title;
            gameToUpdate.Description = updatedGame.Description;
            gameToUpdate.RRP = updatedGame.RRP;
            gameToUpdate.isDeleted = updatedGame.isDeleted;
            gameToUpdate.Genre = updatedGame.Genre;
            gameToUpdate.ImagePath = updatedGame.ImagePath;

            await SaveChanges();

            return gameToUpdate;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
