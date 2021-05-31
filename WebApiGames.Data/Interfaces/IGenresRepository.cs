using System;
using System.Threading.Tasks;
using WebApiGames.Data.Entities;

namespace WebApiGames.Data.Interfaces
{
    public interface IGenresRepository : IGenericRepository<Genres> 
    {
        Task<Genres> GetByName(string name);
    }
}
