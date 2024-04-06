using Microsoft.EntityFrameworkCore;
using CyanCMS.Infraestructure.Data;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;
using CyanCMS.Domain.Dto;

namespace CyanCMS.Infraestructure.Services
{
    public class CompanyService: ICompanyService
    {
        public readonly AppDbContext _dbContext;
        public CompanyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await _dbContext
                    .Company
                    .FindAsync(id);

                if (model != null)
                {
                    model.IsDeleted = true;
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

        public async Task<GenericDto<CompanyDto>> GetAll(CompanyParams @params)
        {
            var query = _dbContext.Company
                .Where(s => !s.IsDeleted);

            if (!string.IsNullOrEmpty(@params.CompanyName))
            {
                query = query.Where(s =>
                   s.Name.Contains(@params.CompanyName)
                );
            }

            if (bool.TryParse(@params.IsActiveStr, out bool isActive) &&
                !string.IsNullOrEmpty(@params.IsActiveStr))
            {
                query = query
                    .Where(s => s.IsActive == isActive
                );
            }
            var totalCount = await query.CountAsync();

            var data = await query              
                .Select(s => new CompanyDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Adress = s.Adress ?? string.Empty,
                    PhoneNumber = s.PhoneNumber ?? string.Empty,
                    Email = s.Email ?? string.Empty
                })
                .OrderBy(s => s.Id) 
                .Skip(@params.PageSize * (@params.PageNumber - 1)) 
                .Take(@params.PageSize) 
                .AsNoTracking()
                .ToListAsync();

            return new GenericDto<CompanyDto>()
            {
                Elements = data,
                TotalCount = totalCount
            };
        }

        public async Task<List<CompanyDto>> GetByUserId(int userId)
        {
            return await _dbContext.Company
                .Where(s => s.UserId == userId && !s.IsDeleted)
                .Select(s => new CompanyDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Adress = s.Adress ?? string.Empty,
                    PhoneNumber = s.PhoneNumber ?? string.Empty,
                    Email = s.Email ?? string.Empty
                })
                .OrderBy(s => s.Id)             
                .AsNoTracking()
                .ToListAsync();    
        }

        public async Task<CompanyDto> GetById(int id)
        {
            return await _dbContext
                .Company
                .Where(s => s.Id == id)
                .Select(s => new CompanyDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Adress = s.Adress,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email,
                    IsActive = s.IsActive,
                    IsDeleted= s.IsDeleted,
                })                
                .FirstOrDefaultAsync() ?? new CompanyDto();          
        }

        public async Task<ResponseModel> Insert(Company model)
        {
            var createModel = new ResponseModel();
            try
            {
                _dbContext.Company.Add(model);
                int insert = await _dbContext.SaveChangesAsync();
                createModel.Status = true;
                createModel.Message = "Se registro con exito";
                createModel.Id = model.Id; 
                
                return createModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                createModel.Status = false;
                createModel.Message = "Error durante la operación de inserción";
                createModel.Id = 0;

                return createModel;
            }
        }

        public async Task<bool> Update(Company model)
        {
            try
            {
                _dbContext.Company.Update(model);
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
