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
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PublisherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeletePublisherAsync(int id)
        {
            await unitOfWork.PublishersRepository.DeleteAsync(id);
            await unitOfWork.Complete();
        }

        public async Task<List<PublisherDTO>> GetAllPublisherAsync()
        {
            var data = await unitOfWork.PublishersRepository.GetAllAsync();

            return mapper.Map<List<PublisherDTO>>(data);
        }

        public async Task<PublisherDTO> GetPublisherByIdAsync(int id)
        {
            var genre = await unitOfWork.PublishersRepository.GetByIdAsync(id);
            return mapper.Map<PublisherDTO>(genre);
        }

        public async Task<int> InsertPublisherAsync(PublisherDTO publisherDTO)
        {
            var publisher = mapper.Map<Publishers>(publisherDTO);
            await unitOfWork.PublishersRepository.AddAsync(publisher);
            await unitOfWork.Complete();
            return publisher.PublisherId;
        }

        public async Task UpdatePublisherAsync(PublisherDTO publisherDTO)
        {
            var publisher = await unitOfWork.PublishersRepository.GetByIdAsync(publisherDTO.PublisherId);
            mapper.Map(publisherDTO, publisher);
            await unitOfWork.Complete();
        }
    }
}
