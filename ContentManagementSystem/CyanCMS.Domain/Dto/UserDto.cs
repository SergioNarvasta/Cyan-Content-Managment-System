
namespace CyanCMS.Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
