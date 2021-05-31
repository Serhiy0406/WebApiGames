using WebApiGames.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Repositories;
using WebApiGames.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApiGames.Data.Repositories
{
    public class DevelopersRepository : BaseRepository<Developers>, IDevelopersRepository
    {
        private readonly ApplicationContext _context;
        public DevelopersRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
    }
}
