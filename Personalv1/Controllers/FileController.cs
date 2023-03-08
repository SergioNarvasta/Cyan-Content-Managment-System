using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal.Interfaces;
using Personal.Models;
using Personal.Repositories;

namespace Personal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileCollection _serviceFile = new FileCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllFile()
        {
            return Ok(await _serviceFile.GetAllFiles());
        }
        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<IActionResult> RegisterFile([FromBody] FileClass file)
        {   
            if (file == null)
                return BadRequest();

             await GuardarArchivo(file.Archivo);

            await _serviceFile.InsertFile(file);
            return Created("Created", true);
        }
        public async Task<string> GuardarArchivo(IFormFile Archivo) {
            var ruta = String.Empty;
            string extension = ".jpg";
            if (Archivo.Length>0)
            {
                var nombreArchivo= Guid.NewGuid().ToString()+ extension;
                ruta = $"Files/{nombreArchivo}";
                using (var stream = new FileStream(ruta,FileMode.Create))
                {
                    await Archivo.CopyToAsync(stream);
                }
            }
            return ruta;
        }

        
    }
}
