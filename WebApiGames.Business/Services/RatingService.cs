using AutoMapper;
using WebApiGames.Data.Interfaces;
using WebApiGames.Business.Interfaces;
using WebApiGames.Business.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApiGames.Business.MapperProfile;
using WebApiGames.Data.Repositories;
using System;
using WebApiGames.Data.Entities;

namespace WebApiGames.Business.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeleteRatingAsync(int id)
        {
            await unitOfWork.RatingsRepository.DeleteAsync(id);
            await unitOfWork.Complete();
        }

        public async Task<List<RatingDTO>> GetAllRatingsAsync()
        {
            var data = await unitOfWork.RatingsRepository.GetAllAsync();

            return mapper.Map<List<RatingDTO>>(data);
        }

        public async Task<RatingDTO> GetRatingByIdAsync(int id)
        {
            var rating = await unitOfWork.RatingsRepository.GetByIdAsync(id);
            return mapper.Map<RatingDTO>(rating);
        }

        public async Task<int> InsertRatingAsync(RatingDTO ratingDTO)
        {
            var rating = mapper.Map<Ratings>(ratingDTO);
            await unitOfWork.RatingsRepository.AddAsync(rating);
            await unitOfWork.Complete();
            return rating.RatingId;
        }

        public async Task UpdateRatingAsync(RatingDTO ratingDTO)
        {
            var rating = await unitOfWork.RatingsRepository.GetByIdAsync(ratingDTO.RatingId);
            mapper.Map(ratingDTO, rating);
            await unitOfWork.Complete();
        }
    }
}
