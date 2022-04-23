namespace MusicPlayer.Models
{
    public class SongsPlaylist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public Song Song { get; set; }
    }
}
