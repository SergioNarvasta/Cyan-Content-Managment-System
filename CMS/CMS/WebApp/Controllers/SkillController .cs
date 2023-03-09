using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal.Interfaces;
using Personal.Models;
using Personal.Repositories;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillCollection _serviceSkill = new SkillCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllFile()
        {
            return Ok(await _serviceSkill.GetAllSkills());
        }

        //[Route("createSkill")]
        [HttpPost]
        public async Task<IActionResult> RegisterSkill([FromBody] Skill skill)
        {   
            if (skill == null)
                return BadRequest();

            skill.Aud_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            skill.Aud_FecAct = DateTime.Now.ToString("dd/MM/yyyy");
            skill.Skill_Estado = 1;

            await _serviceSkill.InsertSkill(skill);
            return Created("Created", true);
        }

    }
}
