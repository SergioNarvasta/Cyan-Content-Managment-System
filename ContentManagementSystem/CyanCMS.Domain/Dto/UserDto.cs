
namespace CyanCMS.Domain.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
