using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace WebApiGames.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
