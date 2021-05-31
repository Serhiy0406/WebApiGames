using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;

namespace WebApiGames.Business.Interfaces
{
    public interface IRatingService
    {
        Task<List<RatingDTO>> GetAllRatingsAsync();
        Task<RatingDTO> GetRatingByIdAsync(int id);
        Task<int> InsertRatingAsync(RatingDTO ratingDTO);
        Task UpdateRatingAsync(RatingDTO ratingDTO);
        Task DeleteRatingAsync(int id);
    }
}
