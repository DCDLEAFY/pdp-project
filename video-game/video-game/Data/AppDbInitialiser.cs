using video_game.Data.Models;

namespace video_game.Data
{
    public class AppDbInitialiser
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Games.Any())
                {
                    context.Games.AddRange(
                        new Game()
                        {
                            Title = "First game",
                            Description = "First Description",
                            Genre = "First Genre",
                            RRP = 1,
                            ImagePath = string.Empty,
                            isDeleted= false
                        },
                        new Game()
                        {
                            Title = "Second game",
                            Description = "Second Description",
                            Genre = "Second Genre",
                            RRP = 2,
                            ImagePath = string.Empty,
                            isDeleted = false
                        },
                        new Game()
                        {
                            Title = "Third game",
                            Description = "Third Description",
                            Genre = "Third Genre",
                            RRP = 3,
                            ImagePath = string.Empty,
                            isDeleted = false
                        }); ;

                    context.SaveChanges();
                }
            }
        }
    }
}
