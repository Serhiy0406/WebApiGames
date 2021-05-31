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
    public class GameService : IGameService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeleteGameAsync(int id)
        {
            await unitOfWork.GamesRepository.DeleteAsync(id);
            await unitOfWork.Complete();
        }

        public async Task<List<GameDTO>> GetAllGamesAsync()
        {
            var data = await unitOfWork.GamesRepository.GetAllAsync();
            return mapper.Map<List<GameDTO>>(data);
        }

        public async Task<List<GameDTO>> GetGameByDeveloperIdAsync(int id)
        {
            var games = await unitOfWork.GamesRepository.GetByDeveloperId(id);
            return mapper.Map<List<GameDTO>>(games);
        }

        public async Task<List<GameDTO>> GetGameByPublisherIdAsync(int id)
        {
            var games = await unitOfWork.GamesRepository.GetByPublisherId(id);
            return mapper.Map<List<GameDTO>>(games);
        }

        public async Task<GameDTO> GetGameByIdAsync(int id)
        {
            var game = await unitOfWork.GamesRepository.GetByIdAsync(id);
            return mapper.Map<GameDTO>(game);
        }

        public async Task<GameDTO> GetGameByNameAsync(string name)
        {
            var game = await unitOfWork.GamesRepository.GetByName(name);
            return mapper.Map<GameDTO>(game);
        }

        public async Task<int> InsertGameAsync(GameDTO gameDTO)
        {
            var game = mapper.Map<Games>(gameDTO);
            await unitOfWork.GamesRepository.AddAsync(game);
            await unitOfWork.Complete();
            return game.GameId;
        }

        public async Task UpdateGameAsync(GameDTO gameDTO)
        {
            var game = await unitOfWork.GenresRepository.GetByIdAsync(gameDTO.GameId);
            mapper.Map(gameDTO, game);
            await unitOfWork.Complete();
        }


    }
}
