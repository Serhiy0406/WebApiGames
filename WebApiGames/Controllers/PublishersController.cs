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
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _service;

        public PublishersController(IPublisherService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDTO>>> GetAll()
        {
            return Ok(await _service.GetAllPublisherAsync());
        }

        // GET api/values/5
        [HttpGet("{PublisherId}")]
        public async Task<ActionResult<PublisherDTO>> Get(int PublisherId)
        {
            var response = await _service.GetPublisherByIdAsync(PublisherId);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PublisherDTO value)
        {
            await _service.InsertPublisherAsync(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{PublisherId}")]
        public async Task<ActionResult> Put([FromBody] PublisherDTO value)
        {
            await _service.UpdatePublisherAsync(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{PublisherId}")]
        public async Task<ActionResult> Delete(int PublisherId)
        {
            await _service.DeletePublisherAsync(PublisherId);
            return NoContent();
        }
    }
}
