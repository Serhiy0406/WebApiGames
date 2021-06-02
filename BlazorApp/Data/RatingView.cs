using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class RatingView
    {
        public int RatingId { get; set; }
        public string Metacritic { get; set; }
        public string E3 { get; set; }
        public string ECTS { get; set; }
        public int CurrentGameId { get; set; }
    }
}
