using Microsoft.EntityFrameworkCore;
using MusicPlayer.Models;
using System;

namespace MusicPlayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<SongList> SongList { get; set; }
        public DbSet<SongsPlaylist> SongsPlaylist { get; set; }
        public DbSet<User> User { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add roles
            Role adminRole = new Role { Id = 1, Name = "admin" };
            Role userRole = new Role { Id = 2, Name = "user" };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            //add users
            User adminUser = new User { Id = 1, Name = "Vladislav Adminovich", Email = "admin@mail.ru", Password = "0000", RoleId = adminRole.Id };
            User userUser = new User { Id = 2, Name = "Vladislav Userovich", Email = "user@mail.ru", Password = "0000", RoleId = userRole.Id };
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, userUser });
            //add genres
            Genre genre1 = new Genre { Id = 1, Name = "Классика" };
            Genre genre2 = new Genre { Id = 2, Name = "Электропоп" };
            modelBuilder.Entity<Genre>().HasData(new Genre[] { genre1, genre2 });
            //add authors
            Author author1 = new Author { Id = 1, Name = "Людвиг ван Бетховен" };
            Author author2 = new Author { Id = 2, Name = "MGMT" };
            modelBuilder.Entity<Author>().HasData(new Author[] { author1, author2 });
            //add albums
            Album album1 = new Album { Id = 1, Name = "Композиции Бетховена", Date = DateTime.Now };
            Album album2 = new Album { Id = 2, Name = "Композиции MGMT", Date = DateTime.Now };
            modelBuilder.Entity<Album>().HasData(new Album[] { album1, album2 });
            //add music
            Song song1 = new Song { Id = 1, Name = "Лунная соната", CoverPath = @"covers/moonlight.jpg", FilePath = @"music/moonlightSonata.mp3", GenreId = 1, AuthorId = 1, AlbumId = 1 };
            Song song2 = new Song { Id = 2, Name = "Little Dark Age", CoverPath = @"covers/lda.jpg", FilePath = @"music/MGMT - Little Dark Age.mp3", GenreId = 2, AuthorId = 2, AlbumId = 2 };

            modelBuilder.Entity<Song>().HasData(new Song[] { song1, song2 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
