using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;

namespace WebApiGames.Business.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherDTO>> GetAllPublisherAsync();
        Task<PublisherDTO> GetPublisherByIdAsync(int id);
        Task<int> InsertPublisherAsync(PublisherDTO publisherDTO);
        Task UpdatePublisherAsync(PublisherDTO publisherDTO);
        Task DeletePublisherAsync(int id);
    }
}
