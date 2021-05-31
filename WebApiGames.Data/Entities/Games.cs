using System;
using System.Collections.Generic;


namespace WebApiGames.Data.Entities
{
    public class Games
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public Ratings Rating { get; set; }

        public int CurrentDeveloperId { get; set; }
        public Developers Developer { get; set; }

        public int CurrentPublisherId { get; set; }
        public Publishers Publisher { get; set; }

        public IList<Genres> Genres { get; set; }
        public IList<BlogUsers> BlogUsers { get; set; }

        public IList<GameGenre> GameGenres { get; set; }
        public IList<GameBlogUser> GameBlogUsers { get; set; }
    }
}
