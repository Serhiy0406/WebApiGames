using System;
using System.Collections.Generic;
using System.Text;
using WebApiGames.Data.Entities;
using WebApiGames.Data.Interfaces;

namespace WebApiGames.Data.Repositories
{
    public class BlogUserRepository : BaseRepository<BlogUsers>, IBlogUsersRepository
    {
        private readonly ApplicationContext _context;
        public BlogUserRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
