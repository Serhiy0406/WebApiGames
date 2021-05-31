using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGames.Data.Entities
{
    public class Publishers
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string OfficialSite { get; set; }
        public IList<Games> Game { get; set; }
    }
}
