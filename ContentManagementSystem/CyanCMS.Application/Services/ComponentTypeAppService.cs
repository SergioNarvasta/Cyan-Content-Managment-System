using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static CyanCMS.Utils.Common.Enums;

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
            model.IsActive = true;
            model.IsDeleted = false;
            return await _componentTypeService.Insert(model);
        }

        public async Task<List<ComponentType>> GetAll() {
            return await _componentTypeService.GetAll();
        }

        public async Task<bool> InsertMultipleComponentType() {
           bool IsDone = true;
           int count = await _componentTypeService.GetCountData();
            int countInserted = 0;
            if(count == 0) {
                foreach (ComponentTypeEnum componentTypeEnum in Enum.GetValues(typeof(ComponentTypeEnum)))
                {
                    DisplayAttribute displayAttribute = GetDisplayAttribute(componentTypeEnum);
                    string displayName = displayAttribute?.Name ?? componentTypeEnum.ToString();

                    ComponentType componentType = new ComponentType
                    {
                        ComponentTypeName = displayName,
                        ComponentTypeDescription = GetComponentDescription((int)componentTypeEnum),
                        IsActive = true,
                        IsDeleted = false,

                    };
                    bool IsInserted = await _componentTypeService.Insert(componentType);
                    if (IsInserted){
                       countInserted++;
                    }  
                }
                if (countInserted > 0){
                    return IsDone;
                }
                
            }
            return !IsDone;
        }

        private static DisplayAttribute? GetDisplayAttribute(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            return (DisplayAttribute?)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));
        }
    }
}
