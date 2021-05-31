using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;

namespace WebApiGames.Business.Interfaces
{
    public interface IBlogUserService
    {
        Task<List<BlogUserDTO>> GetAllBlogUsersAsync();
        Task<BlogUserDTO> GetBlogUserByIdAsync(int id);
        Task<int> InsertBlogUserAsync(BlogUserDTO bloguserDTO);
        Task UpdateBlogUserAsync(BlogUserDTO bloguserDTO);
        Task DeleteBlogUserAsync(int id);
    }
}
