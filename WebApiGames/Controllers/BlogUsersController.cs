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
    public class BlogUsersController : ControllerBase
    {
        private readonly IBlogUserService _service;

        public BlogUsersController(IBlogUserService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogUserDTO>>> GetAll()
        {
            return Ok(await _service.GetAllBlogUsersAsync());
        }

        // GET api/values/5
        [HttpGet("{BlogUserId}")]
        public async Task<ActionResult<BlogUserDTO>> Get(int BlogUserId)
        {
            var response = await _service.GetBlogUserByIdAsync(BlogUserId);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BlogUserDTO value)
        {
            await _service.InsertBlogUserAsync(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{BlogUserId}")]
        public async Task<ActionResult> Put([FromBody] BlogUserDTO value)
        {
            await _service.UpdateBlogUserAsync(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{BlogUserId}")]
        public async Task<ActionResult> Delete(int BlogUserId)
        {
            await _service.DeleteBlogUserAsync(BlogUserId);
            return NoContent();
        }
    }
}
