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
    public class BlogUserService : IBlogUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BlogUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task DeleteBlogUserAsync(int id)
        {
            await unitOfWork.BlogUsersRepository.DeleteAsync(id);
            await unitOfWork.Complete();
        }

        public async Task<List<BlogUserDTO>> GetAllBlogUsersAsync()
        {
            var data = await unitOfWork.BlogUsersRepository.GetAllAsync();

            return mapper.Map<List<BlogUserDTO>>(data);
        }

        public async Task<BlogUserDTO> GetBlogUserByIdAsync(int id)
        {
            var genre = await unitOfWork.BlogUsersRepository.GetByIdAsync(id);
            return mapper.Map<BlogUserDTO>(genre);
        }

        public async Task<int> InsertBlogUserAsync(BlogUserDTO bloguserDTO)
        {
            var bloguser = mapper.Map<BlogUsers>(bloguserDTO);
            await unitOfWork.BlogUsersRepository.AddAsync(bloguser);
            await unitOfWork.Complete();
            return bloguser.BlogUserId;
        }

        public async Task UpdateBlogUserAsync(BlogUserDTO bloguserDTO)
        {
            var bloguser = await unitOfWork.BlogUsersRepository.GetByIdAsync(bloguserDTO.BlogUserId);
            mapper.Map(bloguserDTO, bloguser);
            await unitOfWork.Complete();
        }
    }
}
