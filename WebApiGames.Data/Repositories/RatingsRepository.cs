using WebApiGames.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Repositories;
using WebApiGames.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApiGames.Data.Repositories
{
    public class RatingsRepository : BaseRepository<Ratings>, IRatingsRepository
    {
        private readonly ApplicationContext _context;
        public RatingsRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
