using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;

namespace WebApiGames.Business.Interfaces
{
    public interface IGameService
    {
        Task<List<GameDTO>> GetAllGamesAsync();
        Task<GameDTO> GetGameByIdAsync(int id);
        Task<int> InsertGameAsync(GameDTO gameDTO);
        Task UpdateGameAsync(GameDTO gameDTO);
        Task DeleteGameAsync(int id);
        Task<GameDTO> GetGameByNameAsync(string name);
        Task<List<GameDTO>> GetGameByDeveloperIdAsync(int id);
        Task<List<GameDTO>> GetGameByPublisherIdAsync(int id);
    }
}
