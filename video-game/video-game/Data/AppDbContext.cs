using Microsoft.EntityFrameworkCore;
using video_game.Data.Models;

namespace video_game.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
