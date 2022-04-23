using System;
using System.Collections.Generic;

namespace MusicPlayer.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Song> Songs { get; set; }
    }
}
