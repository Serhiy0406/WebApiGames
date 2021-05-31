using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiGames.Business.DTOs
{
    public class RatingDTO
    {
        public int RatingId { get; set; }
        public string Metacritic { get; set; }
        public string E3 { get; set; }
        public string ECTS { get; set; }
        public int CurrentGameId { get; set; }
    }
}
