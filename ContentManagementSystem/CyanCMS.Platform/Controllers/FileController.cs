
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        //private IFileCollection _serviceFile = new FileCollection();
        /*
        [HttpGet]
        public async Task<IActionResult> GetAllFile()
        {
            return Ok(await _serviceFile.GetAllFiles());
        }

        
        [Consumes("multipart/form-data")]
        [HttpPost]
        [Route("RegisterFile")]
        public async Task<IActionResult> RegisterFile([FromBody] FileClass file)
        {
            if (file.File_Nombre == null)
                return BadRequest();

            var ruta = await GuardarArchivoEnRuta(file.Archivo);
            var fileCreate = new FileCreate();
            fileCreate.Archivo_Nombre = file.Archivo.FileName;
            fileCreate.Archivo_Extension = Path.GetExtension(file.Archivo.FileName);
            fileCreate.Archivo_Tamanio = file.Archivo.Length;
            fileCreate.Archivo_Ubicacion = ruta;
            fileCreate.Archivo_Estado = 1;

            string Base64String = "";
            if (file.Archivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.Archivo.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    Base64String = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }
            fileCreate.Archivo_Base64 = Base64String;
            fileCreate.Aud_UsuCre = "";
            fileCreate.Aud_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            fileCreate.Aud_UsuAct = "";
            fileCreate.Aud_FecAct = DateTime.Now.ToString("dd/MM/yyyy");

            await _serviceFile.InsertFile(fileCreate);
            return Created("Created", true);
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
    */

    }
}

