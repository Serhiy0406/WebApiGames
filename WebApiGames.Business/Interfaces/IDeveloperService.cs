using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;

namespace WebApiGames.Business.Interfaces
{
    public interface IDeveloperService
    {
        Task<List<DeveloperDTO>> GetAllDevelopersAsync();
        Task<DeveloperDTO> GetDeveloperByIdAsync(int id);
        Task<int> InsertDeveloperAsync(DeveloperDTO developerDTO);
        Task UpdateDeveloperAsync(DeveloperDTO developerDTO);
        Task DeleteDeveloperAsync(int id);
    }
}
