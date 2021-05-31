using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Business.DTOs;
using WebApiGames.Business.Interfaces;
using WebApiGames.Data;
using WebApiGames.Data.Entities;
using WebApiGames.Data.Interfaces;

namespace WebApiGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;

        public GamesController(IGameService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetAll()
        {
            return Ok(await _service.GetAllGamesAsync());
        }

        // GET api/values/5
        [HttpGet("{GameId}")]
        public async Task<ActionResult<GameDTO>> Get(int GameId)
        {
            var response = await _service.GetGameByIdAsync(GameId);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GameDTO value)
        {
            await _service.InsertGameAsync(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{GameId}")]
        public async Task<ActionResult> Put([FromBody] GameDTO value)
        {
            await _service.UpdateGameAsync(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{GameId}")]
        public async Task<ActionResult> Delete(int GameId)
        {
            await _service.DeleteGameAsync(GameId);
            return NoContent();
        }

        // GET api/values/5
        [HttpGet("/named/{name}")]
        public async Task<ActionResult<GameDTO>> GetByName(string name)
        {
            var response = await _service.GetGameByNameAsync(name);
            if (response == null) { return NotFound(); }
            return response;
        }

        [HttpGet("/develop/{id}")]
        public async Task<ActionResult<GameDTO>> GetByDeveloperId(int id)
        {
            return Ok(await _service.GetGameByDeveloperIdAsync(id));
            //var response = await _service.GetGameByDeveloperIdAsync(id);
            //if (response == null) { return NotFound(); }
            //return response;
        }

        [HttpGet("/publish/{id}")]
        public async Task<ActionResult<GameDTO>> GetByPublisherId(int id)
        {
            return Ok(await _service.GetGameByPublisherIdAsync(id));
            //var response = await _service.GetGameByPublisherIdAsync(id);
            //if (response == null) { return NotFound(); }
            //return response;
        }
    }
}
