using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Data.Entities
{
    public class Developers
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Characteristic { get; set; }
        public IList<Games> Game { get; set; }
    }
}
