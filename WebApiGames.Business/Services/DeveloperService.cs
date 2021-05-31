using WebApiGames.Business.Interfaces;
using WebApiGames.Business.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApiGames.Business.MapperProfile;
using WebApiGames.Data.Repositories;
using System;
using WebApiGames.Data.Entities;
using WebApiGames.Data.Interfaces;
using AutoMapper;

namespace WebApiGames.Business.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeveloperService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await unitOfWork.DevelopersRepository.DeleteAsync(id);
            await unitOfWork.Complete();
        }
        
        public async Task<List<DeveloperDTO>> GetAllDevelopersAsync()
        {
            var data = await unitOfWork.DevelopersRepository.GetAllAsync();

            return mapper.Map<List<DeveloperDTO>>(data);
        }

        public async Task<DeveloperDTO> GetDeveloperByIdAsync(int id)
        {
            var genre = await unitOfWork.DevelopersRepository.GetByIdAsync(id);
            return mapper.Map<DeveloperDTO>(genre);
        }

        public async Task<int> InsertDeveloperAsync(DeveloperDTO developerDTO)
        {
            var developer = mapper.Map<Developers>(developerDTO);
            await unitOfWork.DevelopersRepository.AddAsync(developer);
            await unitOfWork.Complete();
            return developer.DeveloperId;
        }

        public async Task UpdateDeveloperAsync(DeveloperDTO developerDTO)
        {
            var developer = await unitOfWork.DevelopersRepository.GetByIdAsync(developerDTO.DeveloperId);
            mapper.Map(developerDTO, developer);
            await unitOfWork.Complete();
        }
    }
}
