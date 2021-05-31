using System;
using System.Collections.Generic;


namespace WebApiGames.Data.Entities
{
    public class GameGenre
    {
        public int GameId { get; set; }
        public Games Game { get; set; }
        public int GenreId { get; set; }
        public Genres Genre { get; set; }
    }
}
