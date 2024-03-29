﻿using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Response;

namespace CyanCMS.Application.Interfaces
{
    public interface IConfigurationAppService
    {
        Task<List<Configuration>> GetByCompanyId(int companyId);
        Task<Configuration> GetById(int id);
        Task<int> GetCountByCompany(int companyId);
        Task<CreateModel> Insert(Configuration model);
        Task<bool> Update(Configuration model);
    }
}
