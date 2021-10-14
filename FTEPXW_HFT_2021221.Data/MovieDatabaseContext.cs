﻿using FTEPXW_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Data
{
    class MovieDatabaseContext : DbContext
    {
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Protagonist> Protagonists { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        public MovieDatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieDatabase.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>(e =>
            {
                e
                .HasOne(movie => movie.Protagonist)
                .WithMany(protagonist => protagonist.Movies)
                .HasForeignKey(movie => movie.ProtagonistID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<Movie>(e =>
            {
                e
                .HasOne(movie => movie.Director)
                .WithMany(director => director.Movies)
                .HasForeignKey(movie => movie.DirectorID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Movie interstellar = new Movie()
            {
                MovieId = 1,
                Name = "Interstellar",
                Music = "Hans Zimmer",
                RunningTime = 169,
                Budget = 165000000,
                Genre = "sci-fi",
                AgeLimit = 12,
                Income = 677463813
            };
            Movie inception = new Movie()
            {
                MovieId = 2,
                Name = "Inception",
                Music = "Hans Zimmer",
                RunningTime = 148,
                Budget = 160000000,
                Genre = "drama",
                AgeLimit = 16,
                Income = 160500000
            };
            Movie dunkirk = new Movie()
            {
                MovieId = 3,
                Name = "Dunkirk",
                Music = "Hans Zimmer",
                RunningTime = 106,
                Budget = 100000000,
                Genre = "war",
                AgeLimit = 16,
                Income = 526940665
            };
            Movie hangover = new Movie()
            {
                MovieId = 4,
                Name = "Hangover",
                Music = "Christophe Beck",
                RunningTime = 100,
                Budget = 35000000,
                Genre = "comedy",
                AgeLimit = 12,
                Income = 467000000
            };
            Movie callmebyyourname = new Movie()
            {
                MovieId = 5,
                Name = "Call me by your name",
                Music = "Sufjan Stevens",
                RunningTime = 132,
                Budget = 3500000,
                Genre = "drama",
                AgeLimit = 16,
                Income = 4190000
            };
            Movie gentlemen = new Movie()
            {
                MovieId = 6,
                Name = "Gentlemen",
                Music = "Guy Ritchie",
                RunningTime = 113,
                Budget = 22000000,
                Genre = "action",
                AgeLimit = 18,
                Income = 115200000
            };
            Movie thegreatgatsby = new Movie()
            {
                MovieId = 7,
                Name = "The Great Gatsby",
                Music = "Baz Luhrmann",
                RunningTime = 142,
                Budget = 190000000,
                Genre = "drama",
                AgeLimit = 18,
                Income = 353600000
            };
            Movie forrestgump = new Movie()
            {
                MovieId = 8,
                Name = "Forrest Gump",
                Music = "Alan Silvestri",
                RunningTime = 142,
                Budget = 55000000,
                Genre = "drama",
                AgeLimit = 12,
                Income = 683100000
            };
            Movie dune = new Movie()
            {
                MovieId = 9,
                Name = "Dune",
                Music = "Hans Zimmer.",
                RunningTime = 155,
                Budget = 165000000,
                Genre = "sci-fi",
                AgeLimit = 16,
                Income = 117600000
            };

            // ---------------------------------------

            Protagonist matthewmcconaughey = new Protagonist()
            {
                ProtagonistID = 1,
                Name = "Matthew McConaughey",
                CharacterName = "Cooper",
                Age = 51,
                Gender = "man",
                Oscar = true
            };
            Protagonist leonardodicaprio = new Protagonist()
            {
                ProtagonistID = 2,
                Name = "Leonardo DiCaprio",
                CharacterName = "Dominick Cobb",
                Age = 46,
                Gender = "man",
                Oscar = true
            };
            Protagonist fionnwhitehead = new Protagonist()
            {
                ProtagonistID = 3,
                Name = "Fionn Whitehead",
                CharacterName = "Fionn Whitehead's",
                Age = 24,
                Gender = "man",
                Oscar = false
            };
            Protagonist bradleycharlescooper = new Protagonist()
            {
                ProtagonistID = 4,
                Name = "Bradley Charles Cooper",
                CharacterName = "Philip Wenneck",
                Age = 46,
                Gender = "man",
                Oscar = false
            };
            Protagonist timotheechalamet = new Protagonist()
            {
                ProtagonistID = 5,
                Name = "Timothée Chalamet",
                CharacterName = "Elio Perlman",
                Age = 25,
                Gender = "man",
                Oscar = false
            };
            Protagonist tomhanks = new Protagonist()
            {
                ProtagonistID = 6,
                Name = " Tom Hanks",
                CharacterName = "Forrest Gump",
                Age = 65,
                Gender = "man",
                Oscar = true
            };

            // ---------------------------------------

            Director robertzemeckis = new Director()
            {
                DirectorID = 1,
                Name = "Robert Zemeckis",
                Age = 69,
                Gender = "man"         
            };
            Director christophernolan = new Director()
            {
                DirectorID = 2,
                Name = "Christopher Nolan",
                Age = 51,
                Gender = "man"
            };
            Director toddphillips = new Director()
            {
                DirectorID = 3,
                Name = "Todd Phillips",
                Age = 50,
                Gender = "man"
            };
            Director lucaguadagnino = new Director()
            {
                DirectorID = 4,
                Name = "Luca Guadagnino",
                Age = 50,
                Gender = "man"
            };
            Director guyritchie = new Director()
            {
                DirectorID = 5,
                Name = "Guy Ritchie",
                Age = 53,
                Gender = "man"
            };
            Director bazluhrmann = new Director()
            {
                DirectorID = 6,
                Name = "Baz Luhrmann",
                Age = 59,
                Gender = "man"
            };
            Director denisvilleneuve = new Director()
            {
                DirectorID = 7,
                Name = "Denis Villeneuve",
                Age = 54,
                Gender = "man"
            };

            // ---------------------------------------

            mb.Entity<Movie>().HasData(interstellar, inception, dunkirk,
                hangover, callmebyyourname, gentlemen, thegreatgatsby,
                forrestgump, dune);

            mb.Entity<Protagonist>().HasData(matthewmcconaughey, leonardodicaprio,
                fionnwhitehead, bradleycharlescooper, timotheechalamet,
                tomhanks);

            mb.Entity<Director>().HasData(robertzemeckis, christophernolan,
                toddphillips, lucaguadagnino, guyritchie, guyritchie, bazluhrmann,
                denisvilleneuve);
        }


    }
}
