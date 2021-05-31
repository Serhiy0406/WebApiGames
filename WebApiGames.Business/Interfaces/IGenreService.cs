using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;

namespace WebApiGames.Business.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> GetGenreByIdAsync(int id);
        Task<int> InsertGenreAsync(GenreDTO genreDTO);
        Task UpdateGenreAsync(GenreDTO genreDTO);
        Task DeleteGenreAsync(int id);
        Task<GenreDTO> GetGenreByNameAsync(string name);
    }
}
