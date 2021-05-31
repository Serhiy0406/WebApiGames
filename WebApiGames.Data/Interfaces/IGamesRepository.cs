using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Data.Entities;

namespace WebApiGames.Data.Interfaces
{
    public interface IGamesRepository : IGenericRepository<Games>
    {
        Task<Games> GetByName(string name);
        Task<IEnumerable<Games>> GetByPublisherId(int id);
        Task<IEnumerable<Games>> GetByDeveloperId(int id);
    }
}
