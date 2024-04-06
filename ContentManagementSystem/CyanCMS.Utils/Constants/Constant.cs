
namespace CyanCMS.Utils.Constants
{
    public class Constant
    {
        public const string key_CurrentSession = "key_CurrentSession";
        public const string key_CompaniesByUserSession = "key_CompaniesByUserSession";
    }

    public class ResponseMessage
    {
        public const string RegisterSucess = "Se registro con exito";
        public const string UpdateSucess = "Se actualizo con exito";
        public const string DeleteSucess = "Se elimino con exito";
        public const string LoginSucess = "Inicio de Sesion Exitoso";
        public const string LoginError = "Inicio de sesion no valido, verifique credenciales!";
        public const string OperationError = "Ocurrio un error !";
    }

    public class TimeSession
    {
        public readonly static TimeSpan UserSession = TimeSpan.FromMinutes(240);
    }
}
