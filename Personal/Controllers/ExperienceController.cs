using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal.Models;
using Personal.Repositories;

namespace Personal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private IExperienceCollection db = new ExperienceCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllExperiences()
        {
            return Ok(await db.GetAllExperiences());
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperience([FromBody] Experience experience)
        {
            if (experience == null)
                return BadRequest();

            if (experience.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El proyecto no debe ser vacio");
            }
            await db.InsertExperience(experience);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateExperience([FromBody] Experience experience,string id)
        {
            if (experience == null)
                return BadRequest();

            if (experience.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El proyecto no debe ser vacio");
            }
            experience.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateExperience(experience);
            return Created("Update", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExperience(string id) 
        {
            await db.DeleteExperience(id);
            return NoContent();
        }
    }
}
