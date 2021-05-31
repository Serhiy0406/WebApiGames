using System;
using System.Collections.Generic;


namespace WebApiGames.Data.Entities
{
    public class BlogUsers
    {
        public int BlogUserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public IList<GameBlogUser> GameBlogUsers { get; set; }

        public IList<Games> Games { get; set; }
    }
}
