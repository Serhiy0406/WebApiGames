using System;
using System.Collections.Generic;



namespace WebApiGames.Data.Entities
{
    public class Genres
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<GameGenre> GameGenre { get; set; }

        public IList<Games> Games { get; set; }
    }
}
