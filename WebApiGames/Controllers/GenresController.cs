
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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenresController(IGenreService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll()
        {
            return Ok(await _service.GetAllGenresAsync());
        }

        // GET api/values/5
        [HttpGet("{GenreId}")]
        public async Task<ActionResult<GenreDTO>> Get(int GenreId)
        {
            var response = await _service.GetGenreByIdAsync(GenreId);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreDTO value)
        {
            await _service.InsertGenreAsync(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{GenreId}")]
        public async Task<ActionResult> Put([FromBody] GenreDTO value)
        {
            await _service.UpdateGenreAsync(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{GenreId}")]
        public async Task<ActionResult> Delete(int GenreId)
        {
            await _service.DeleteGenreAsync(GenreId);
            return NoContent();
        }

        // GET api/values/5
        [HttpGet("/genrenamed/{name}")]
        public async Task<ActionResult<GenreDTO>> GetByName(string name)
        {
            var response = await _service.GetGenreByNameAsync(name);
            if (response == null) { return NotFound(); }
            return response;
        }

    }
}
