using System;
using System.Collections.Generic;


namespace WebApiGames.Data.Entities
{
    public class GameBlogUser
    {
        public int GameId { get; set; }
        public Games Game { get; set; }
        public int BlogUserId { get; set; }
        public BlogUsers BlogUser { get; set; }
    }
}
