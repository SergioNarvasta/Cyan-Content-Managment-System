
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;
using CyanCMS.Utils.Constants;

namespace CyanCMS.Infraestructure.Services
{
    public class ComponentService : IComponentService
    {
        public readonly AppDbContext _dbContext;
        public ComponentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await _dbContext
                    .Component
                    .FindAsync(id);

                if (model != null)
                {
                    model.IsDeleted = true;
                    model.IsActive = false;
                    await this.Update(model);
                    
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }           
        }

        public async Task<IEnumerable<Component>> GetAll(ComponentParams @params)
        {
            var query = _dbContext.Component
                .AsQueryable();

            if (!string.IsNullOrEmpty(@params.ComponentName))
            {
                query = query.Where(s =>
                   s.Name.Contains(@params.ComponentName)
                );
            }

            bool isActive;
            if (bool.TryParse(@params.IsActiveStr, out isActive) &&
                !string.IsNullOrEmpty(@params.IsActiveStr))
            {
                query = query
                    .Where(s => s.IsActive == isActive
                );
            }

            if (!string.IsNullOrEmpty(@params.CompanyId))
            {
                query = query.Where(s =>
                   s.CompanyId == int.Parse(@params.CompanyId)
                );
            }

            if (!string.IsNullOrEmpty(@params.ComponentType))
            {
                query = query.Where(s =>
                   s.ComponentTypeId == int.Parse(@params.ComponentType)
                );
            }

            var list = await query
                 .Where(s => !s.IsDeleted)
                 .AsNoTracking()
                 .ToListAsync();

            return list
                .Skip(@params.PageNumber)
                .Take(@params.PageSize);
        }

        public async Task<Component> GetById(int id)
        {
            var componentEmpty = new Component();
            return await _dbContext
                .Component
                .FindAsync(id) ?? componentEmpty;
        }

        public async Task<CreateModel> Insert(Component model)
        {
            var createModel = new CreateModel();
            try
            {
                await _dbContext.Component.AddAsync(model);
                int insert = await _dbContext.SaveChangesAsync();

                createModel.WasCreated = true;
                createModel.Message = ResponseMessage.RegisterSucess;
                createModel.Id = model.Id;              
                return createModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                createModel.WasCreated = false;
                createModel.Message = ResponseMessage.OperationError;
                createModel.Id = 0;

                return createModel;
            }
        }

        public async Task<bool> Update(Component model)
        {
            try
            {
                _dbContext.Component.Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
    }
}
