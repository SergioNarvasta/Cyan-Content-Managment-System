using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal.Interfaces;
using Personal.Models;
using Personal.Repositories;

namespace Personal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private IFileCollection _serviceFile = new FileCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllFile()
        {
            return Ok(await _serviceFile.GetAllFiles());
        }
        [Route("RegisterSkill")]
        [HttpPost]
        public async Task<IActionResult> RegisterSkill([FromBody] Skill skill)
        {   
            if (skill == null)
                return BadRequest();

            await _serviceFile.InsertFile(fileCreate);
            return Created("Created", true);
        }

    }
}
