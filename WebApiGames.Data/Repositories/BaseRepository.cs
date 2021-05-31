using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
//using WebApiGames.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiGames.Data.Interfaces;

namespace WebApiGames.Data.Repositories
{
    public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

      
        /////////////////  Add/create
        public async Task<TEntity> AddAsync(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            return obj;
        }
        /////////////////  Delete
        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(obj);
        }

        /////////////////  GetAll
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var res = await _context.Set<TEntity>().ToListAsync();
            return res;
        }

        /////////////////  GetById
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

    }
}
