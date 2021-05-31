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
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _service;

        public DevelopersController(IDeveloperService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperDTO>>> GetAll()
        {
            return Ok(await _service.GetAllDevelopersAsync());
        }

        // GET api/values/5
        [HttpGet("{DeveloperId}")]
        public async Task<ActionResult<DeveloperDTO>> Get(int DeveloperId)
        {
            var response = await _service.GetDeveloperByIdAsync(DeveloperId);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DeveloperDTO value)
        {
            await _service.InsertDeveloperAsync(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{DeveloperId}")]
        public async Task<ActionResult> Put([FromBody] DeveloperDTO value)
        {
            await _service.UpdateDeveloperAsync(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{DeveloperId}")]
        public async Task<ActionResult> Delete(int DeveloperId)
        {
            await _service.DeleteDeveloperAsync(DeveloperId);
            return NoContent();
        }
    }
}
