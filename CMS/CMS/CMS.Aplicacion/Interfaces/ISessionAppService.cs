using CMS.Dominio.Entidades;
using ReactVentas.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Aplicacion.Interfaces
{
	public interface ISessionAppService
	{
		Task<User> Session(Dtosesion request);
	}
}
