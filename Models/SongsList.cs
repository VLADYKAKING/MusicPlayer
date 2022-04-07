namespace MusicPlayer.Models
{
    public class SongsList
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
