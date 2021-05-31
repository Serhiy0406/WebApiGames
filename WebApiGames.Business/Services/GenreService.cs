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
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeleteGenreAsync(int id)
        {
            await unitOfWork.GenresRepository.DeleteAsync(id);
            await unitOfWork.Complete();
        }

        public async Task<List<GenreDTO>> GetAllGenresAsync()
        {
            var data = await unitOfWork.GenresRepository.GetAllAsync();

            return mapper.Map<List<GenreDTO>>(data);
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int id)
        {
            var genre = await unitOfWork.GenresRepository.GetByIdAsync(id);
            return mapper.Map<GenreDTO>(genre);
        }
        
        public async Task<GenreDTO> GetGenreByNameAsync(string name)
        {
            var genre = await unitOfWork.GenresRepository.GetByName(name);
            return mapper.Map<GenreDTO>(genre);
        }

        public async Task<int> InsertGenreAsync(GenreDTO genreDTO)
        {
            var genre = mapper.Map<Genres>(genreDTO);
            await unitOfWork.GenresRepository.AddAsync(genre);
            await unitOfWork.Complete();
            return genre.GenreId;
        }

        public async Task UpdateGenreAsync(GenreDTO genreDTO)
        {
            var genre = await unitOfWork.GenresRepository.GetByIdAsync(genreDTO.GenreId);
            mapper.Map(genreDTO, genre);
            await unitOfWork.Complete();
        }
    }
}
