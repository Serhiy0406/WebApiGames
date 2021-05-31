using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Entities;

namespace WebApiGames.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Developers> Developers { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Games> Games { get; set; }

        //public DbSet<GameGenre> GameGenre { get; set; }
        //public DbSet<GameBlogUser> GameBlogUser { get; set; }
        public DbSet<BlogUsers> BlogUsers { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        public ApplicationContext()
        {
              //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              optionsBuilder.UseSqlServer(@"Server=DESKTOP-K6O5D7R\SQLEXPRESS;Database=WebApiGames;Trusted_Connection=True;");///Server=(localdb)\MSSQLLocalDB
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///////////////////////////////primary keys
            modelBuilder.Entity<Developers>().HasKey(d => d.DeveloperId);
            modelBuilder.Entity<Publishers>().HasKey(p => p.PublisherId);
            modelBuilder.Entity<Ratings>().HasKey(r => r.RatingId);
            modelBuilder.Entity<BlogUsers>().HasKey(bu => bu.BlogUserId);
            modelBuilder.Entity<Genres>().HasKey(g => g.GenreId);
            modelBuilder.Entity<Games>().HasKey(g => g.GameId);

            ///////////////////////////////GameGenre    many to many
            
            //modelBuilder.Entity<Games>()
            //    .HasMany(g => g.Genres)
            //    .WithMany(u => u.Games)
            //    .UsingEntity(j => j.ToTable("GameGenre"));


            modelBuilder
                .Entity<Games>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Games)
                .UsingEntity<GameGenre>( ///////////
                   j => j
                    .HasOne(pt => pt.Genre)
                    .WithMany(t => t.GameGenre)
                    .HasForeignKey(pt => pt.GenreId),
                j => j
                    .HasOne(pt => pt.Game)
                    .WithMany(p => p.GameGenres)
                    .HasForeignKey(pt => pt.GameId),
                j =>
                {
                    j.HasKey(t => new { t.GameId, t.GenreId });
                    j.ToTable("GameGenre");
                }
            );

            ///////////////////////////////developer     one to many
            modelBuilder.Entity<Games>()
                .HasOne<Developers>(g => g.Developer)
                .WithMany(d => d.Game)
                .HasForeignKey(g => g.CurrentDeveloperId);
            ///////////////////////////////publisher     one to many
            modelBuilder.Entity<Games>()
                .HasOne<Publishers>(g => g.Publisher)
                .WithMany(p => p.Game)
                .HasForeignKey(s => s.CurrentPublisherId);
            //////////////////////////////////Rating    One to one
            modelBuilder.Entity<Games>()
                .HasOne<Ratings>(g => g.Rating)
                .WithOne(r => r.Game)
                .HasForeignKey<Ratings>(g => g.CurrentGameId);
            //////////////////////////////////GameBlogUser   many to many

            //modelBuilder.Entity<Games>()
            //    .HasMany(g => g.BlogUsers)
            //    .WithMany(u => u.Games)
            //    .UsingEntity(j => j.ToTable("GameBlogUser"));

            modelBuilder
                .Entity<Games>()
                .HasMany(c => c.BlogUsers)
                .WithMany(s => s.Games)
                .UsingEntity<GameBlogUser>(
                   j => j
                    .HasOne(pt => pt.BlogUser)
                    .WithMany(t => t.GameBlogUsers)
                    .HasForeignKey(pt => pt.BlogUserId),
                j => j
                    .HasOne(pt => pt.Game)
                    .WithMany(p => p.GameBlogUsers)
                    .HasForeignKey(pt => pt.GameId),
                j =>
                {
                    j.HasKey(t => new { t.GameId, t.BlogUserId });
                    j.ToTable("GameBlogUser");
                }
            );

            modelBuilder.Entity<Genres>().Property(g => g.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Developers>().Property(d => d.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Publishers>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Games>().Property(g => g.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Games>().Property(g => g.Cost).IsRequired().HasPrecision(9, 2);

        }
    }
}
