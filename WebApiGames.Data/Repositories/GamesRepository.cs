using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Data.Entities;
using WebApiGames.Data.Interfaces;

namespace WebApiGames.Data.Repositories
{
    public class GamesRepository : BaseRepository<Games>, IGamesRepository
    {
        private readonly ApplicationContext _context;
        public GamesRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Games>> GetByDeveloperId(int id) /*CurrentDeveloperId*/
        {
            var res = await _context.Set<Games>().Where(g => g.CurrentDeveloperId == id).ToListAsync();
            return res;
        }
        public async Task<IEnumerable<Games>> GetByPublisherId(int id) /*CurrentPublisherId*/
        {
            var res = await _context.Set<Games>().Where(g => g.CurrentPublisherId == id).ToListAsync();
            return res;
        }
        public async Task<Games> GetByName(string name)
        {
            return await _context.Set<Games>().AsNoTracking().FirstOrDefaultAsync(g => g.Name == name);
        }
    }
}
