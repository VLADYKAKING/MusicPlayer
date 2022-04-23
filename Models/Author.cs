using System.Collections.Generic;

namespace MusicPlayer.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
