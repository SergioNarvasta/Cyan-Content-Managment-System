﻿using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;

namespace CyanCMS.Application.Interfaces
{
	public interface ICompanyAppService
	{
		Task<bool> Delete(string id);
		Task<IEnumerable<Company>> GetAll(CompanyParams @params);
		Task<Company> GetById(string company_Pk);
		int GetTotalCount();

        Task<CreateModel> Insert(Company model);
		Task<bool> Update(Company model);
	}
}