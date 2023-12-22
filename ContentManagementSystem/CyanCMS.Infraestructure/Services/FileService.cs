
using CyanCMS.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;

namespace CyanCMS.Infraestructure.Services
{
    public class FileService : IFileService
    {
        private readonly AppDbContext _dbContext;
        public FileService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FileUnit> GetByCompany(int companyId)
        {
            var fileempty = new FileUnit();
            var files = await _dbContext
                 .File
                 .Where(s => !s.IsDeleted && s.IsActive &&
                       s.CompanyId == companyId)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            return files ?? fileempty;
        }

        public async Task<List<FileUnit>> GetByComponent(int componentId)
        {
            return await _dbContext
                 .File
                 .Where(s => !s.IsDeleted && s.IsActive &&
                        s.ComponentId == componentId)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<bool> Insert(FileUnit file)
        {
            try
            {
                await _dbContext.File.AddAsync(file);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            } 
        }

        public async Task<bool> Update(FileUnit file)
        {
            try
            {
                _dbContext.File.Update(file);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }  
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await _dbContext
                    .File
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
    }
}
