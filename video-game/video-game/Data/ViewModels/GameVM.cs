namespace video_game.Data.ViewModels
{
    public class GameVM
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Genre { get; set; }

        public double? RRP { get; set; }

        public string ImagePath { get; set; }

        public Boolean? isDeleted { get; set; }
    }
}
