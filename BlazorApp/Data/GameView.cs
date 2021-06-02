using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class GameView
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int CurrentDeveloperId { get; set; }
        public int CurrentPublisherId { get; set; }
    }
}
