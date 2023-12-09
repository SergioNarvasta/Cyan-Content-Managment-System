using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using static Utils.Enums;


namespace CyanCMS.Application.Services
{
    public class ComponentTypeAppService : IComponentTypeAppService
    {
        private readonly IComponentTypeService _componentTypeService;
        public ComponentTypeAppService(IComponentTypeService componentTypeService) {
            _componentTypeService = componentTypeService;
        }

        public async Task<bool> Insert(ComponentType model)
        {
            return await _componentTypeService.Insert(model);
        }

        public async Task<bool> InsertMultipleComponentType() {
            bool IsDone = true;
           int count = await _componentTypeService.GetCountData();
            if(count > 0) {
                foreach (ComponentTypeEnum componentTypeEnum in Enum.GetValues(typeof(ComponentTypeEnum)))
                {
                    ComponentType componentType = new ComponentType
                    {
                        ComponentTypeName = componentTypeEnum.ToString(),
                        ComponentTypeDescription = $"Description for {componentTypeEnum}"
                        
                    };

                   
                }

                return IsDone;
            }
            return !IsDone;
        }
    }
}
