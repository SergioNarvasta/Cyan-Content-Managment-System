using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal.Interfaces;
using Personal.Models;
using Personal.Repositories;

namespace WebApp.Controllers
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
        [Route("registro")]
        public async Task<ActionResult<string>> RegisterFileAsync([FromBody] IFormFile file)
        {
            if (file == null)
                return BadRequest();

            var ruta = await GuardarArchivoEnRuta(file);
            var fileCreate = new FileCreate();
            fileCreate.Archivo_Pk = Guid.NewGuid().ToString();
            fileCreate.Archivo_Nombre = file.FileName;
            fileCreate.Archivo_Extension = Path.GetExtension(file.FileName);
            fileCreate.Archivo_Tamanio = file.Length;
            fileCreate.Archivo_Ubicacion = ruta;
            fileCreate.Archivo_Estado = 1;

            string Base64String = "";
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    Base64String = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }
            fileCreate.Archivo_Base64 = Base64String;
            fileCreate.Aud_UsuCre = "SNarvasta";
            fileCreate.Aud_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            fileCreate.Aud_UsuAct = "";
            fileCreate.Aud_FecAct = DateTime.Now.ToString("dd/MM/yyyy");

            await _serviceFile.InsertFile(fileCreate);
            return Ok(fileCreate.Archivo_Pk);
        }
        public async Task<string> GuardarArchivoEnRuta(IFormFile Archivo)
        {
            var ruta = String.Empty;
            string extension = Path.GetExtension(Archivo.FileName); ;
            if (Archivo.Length > 0)
            {
                var nombreArchivo = Guid.NewGuid().ToString() + extension;
                ruta = $"1.Files/{nombreArchivo}";
                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await Archivo.CopyToAsync(stream);
                }
            }
            return ruta;
        }


    }
}
