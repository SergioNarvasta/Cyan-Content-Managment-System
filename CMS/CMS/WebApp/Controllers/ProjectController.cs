using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectCollection _serviceProject = new ProjectCollection();
        private IFileCollection _serviceFile = new FileCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _serviceProject.GetAllProjects());
        }


        [Route("createProject")]
        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            if (project == null)
                return BadRequest();

            if (project.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El proyecto no debe ser vacio");
            }
            //project.RutaArchivo = await GuardarArchivoEnRuta(project.Archivo);
            project.FechaRegistro = DateTime.Now;

            await _serviceProject.InsertProject(project);
            return Created("Created", true);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> CreateProject([FromBody] Project project, string id)
        {
            if (project == null)
                return BadRequest();

            if (project.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El proyecto no debe ser vacio");
            }
            project.Id = new MongoDB.Bson.ObjectId(id);
            await _serviceProject.UpdateProject(project);
            return Created("Update", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(string id)
        {
            await _serviceProject.DeleteProject(id);
            return NoContent();
        }


    }
}
