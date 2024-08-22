using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBy()
        {
            return Ok();
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Rewrite(Guid id)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Patch(Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
