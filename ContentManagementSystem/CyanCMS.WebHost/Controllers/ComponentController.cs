
using Cyan.Utils.Common;
using CyanCMS.Application.Interfaces;
using CyanCMS.Utils.Common;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using static CyanCMS.Utils.Request.RequestModels;

namespace CyanCMS.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentAppService _componentAppService;
        private readonly IFileAppService _fileAppService;

        public ComponentController(IComponentAppService componentAppService,
            IFileAppService fileAppService) 
        {
			_componentAppService = componentAppService;
            _fileAppService = fileAppService;
        }

        [Route("GetAllComponent")]
        [HttpGet]
        public async Task<IActionResult> GetAllComponent([FromBody] RequestParams? @params)
        {
            string NameFilter = string.Empty;
            string TypeIdFilter = string.Empty;
            string IsActiveFilter = string.Empty;
            var queryParams = new ComponentParams();

            if (@params != null) {
                var attributeValues = DataQueryOperations.GetAttributeValues(@params.Filters);
                foreach (var attribute in attributeValues)
                {
                    if (attribute.Key == "componentName") {
                        NameFilter = attribute.Value;
                    }
                     else if (attribute.Key == "isActive")
                    {
                        IsActiveFilter = attribute.Value;
                    }
                    else if (attribute.Key == "typeId")
                    {
                        TypeIdFilter = attribute.Value;
                    }
                }
                var componentParams = new ComponentParams
                {
                    ComponentName = NameFilter,
                    IsActiveStr = IsActiveFilter,
                    ComponentType = TypeIdFilter,
                    PageSize = @params.PageSize,
                    PageNumber = @params.PageNumber,
                };
                queryParams = componentParams;
            }

            return Ok(await _componentAppService.GetAll(queryParams));
        }

        [Route("GetComponentById")]
        [HttpPost]
        public async Task<IActionResult> GetComponentById(int id)
        {
            return Ok(await _componentAppService.GetById(id));
        }

        [Route("CreateComponent")]
        [HttpPost]
        public async Task<IActionResult> CreateComponent([FromBody] CreateComponentModel model)
        {
            if (model.Component == null)
                return BadRequest();

            var result = await _componentAppService.Insert(model.Component);

            // Se realizara la insersion de archivos en segundo plano como un Job en la v2
            if (result.WasCreated && model.Files != null) {

                foreach (var file in model.Files)
                {
                    file.ComponentId = result.Id;
                    await _fileAppService.Insert(file);
                }                                  
            }
            var response = new ResponseModel()
            {
                Status = result.WasCreated,
                Message = result.WasCreated ? "Se registro exito" : "Error en creacion"       
            };
            return Created("Created", response);
        }

        [Route("UpdateComponent")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreateComponentModel model)
        {
            if (model.Component == null)
                return BadRequest();

            var result = await _componentAppService.Update(model.Component);
            if ( model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    await _fileAppService.Update(file);
                }
            }
            var response = new ResponseModel()
            {
                Status = result,
                Message = result ? "Se actualizo exito" : "Error en actualizacion"
            };
            return Created("Update", response);
		}

		[Route("DeleteComponent")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] int id)
		{
			await _componentAppService.Delete(id);
			return NoContent();
		}
	}
}
