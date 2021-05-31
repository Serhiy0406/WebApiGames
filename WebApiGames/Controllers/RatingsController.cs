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
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingsController(IRatingService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDTO>>> GetAll()
        {
            return Ok(await _service.GetAllRatingsAsync());
        }

        // GET api/values/5
        [HttpGet("{RatingId}")]
        public async Task<ActionResult<RatingDTO>> Get(int RatingId)
        {
            var response = await _service.GetRatingByIdAsync(RatingId);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RatingDTO value)
        {
            await _service.InsertRatingAsync(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{RatingId}")]
        public async Task<ActionResult> Put([FromBody] RatingDTO value)
        {
            await _service.UpdateRatingAsync(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{RatingId}")]
        public async Task<ActionResult> Delete(int RatingId)
        {
            await _service.DeleteRatingAsync(RatingId);
            return NoContent();
        }
    }
}
