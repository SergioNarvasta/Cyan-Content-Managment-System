using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal.Models;
using Personal.Repositories;

namespace Personal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectCollection db = new ProjectCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await db.GetAllProjects());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            if (project == null)
                return BadRequest();

            if (project.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El proyecto no debe ser vacio");
            }
            await db.InsertProject(project);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateProject([FromBody] Project project,string id)
        {
            if (project == null)
                return BadRequest();

            if (project.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El proyecto no debe ser vacio");
            }
            project.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProject(project);
            return Created("Update", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(string id) 
        {
            await db.DeleteProject(id);
            return NoContent();
        }
    }
}
