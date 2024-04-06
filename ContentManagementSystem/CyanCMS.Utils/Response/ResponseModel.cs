using CyanCMS.Domain.Dto;

namespace CyanCMS.Utils.Response
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }      
    }

    public class CreateModel
    {
        public bool WasCreated { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
    }

    public class ResponseLogin
    {
        public ResponseModel Response { get; set; }
        public UserDto User { get; set; }
        public List<CompanyDto> Companies { get; set; }
    }
}
