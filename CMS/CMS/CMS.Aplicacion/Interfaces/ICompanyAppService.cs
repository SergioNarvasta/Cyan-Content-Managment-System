using CMS.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Aplicacion.Interfaces
{
	public interface ICompanyAppService
	{
		Task DeleteCompany(string id);
		Task<IEnumerable<Company>> GetAllCompany();
		Task<Company> GetCompanyById(string id);
		Task InsertCompany(Company company);
		Task UpdateCompany(Company company);
	}
}
