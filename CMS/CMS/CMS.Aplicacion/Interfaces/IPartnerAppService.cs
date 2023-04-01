using CMS.Dominio.Entidades;

namespace CMS.Aplicacion.Interfaces
{
    public interface IPartnerAppService
	{
        Task Delete(string id);
        Task<IEnumerable<Partner>> GetAll();
		Task<Partner> GetById(string id);
		Task Insert(Partner model);
        Task Update(Partner model);
    }
}
