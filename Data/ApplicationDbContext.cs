﻿using Microsoft.EntityFrameworkCore;
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
            Genre genre = new Genre { Id = 1, Name = "Классика" };
            modelBuilder.Entity<Genre>().HasData(new Genre[] { genre });
            //add authors
            Author author = new Author { Id = 1, Name = "Людвиг ван Бетховен" };
            modelBuilder.Entity<Author>().HasData(new Author[] { author });
            //add albums
            Album album = new Album { Id = 1, Name = "Композиции Бетховена", Date = DateTime.Now };
            modelBuilder.Entity<Album>().HasData(new Album[] { album });
            //add music
            Song song = new Song { Id = 1, Name = "Лунная соната", CoverPath = @"covers/moonlight.jpg", FilePath = @"music/moonlightSonata.mp3", GenreId = 1, AuthorId = 1, AlbumId = 1 };
            modelBuilder.Entity<Song>().HasData(new Song[] { song });

            base.OnModelCreating(modelBuilder);
        }
    }
}
