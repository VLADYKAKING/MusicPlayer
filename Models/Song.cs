namespace MusicPlayer.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverPath { get; set; }
        public string FilePath { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int AlbumId { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public Album Album { get; set; }

    }
}
