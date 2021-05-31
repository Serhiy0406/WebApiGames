using WebApiGames.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Repositories;
using WebApiGames.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApiGames.Data
{
    public class GenresRepository : BaseRepository<Genres>, IGenresRepository
    {
        private readonly ApplicationContext _context;
        public GenresRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /////////////////  GetByName
        public async Task<Genres> GetByName(string name)
        {
            return await _context.Set<Genres>().AsNoTracking().FirstOrDefaultAsync(g => g.Name == name);
        }
        
    }
}
