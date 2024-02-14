
namespace CyanCMS.Domain.Dto
{
    public class GenericDto<T>
    {
        public List<T> Elements { get; set; }
        public int TotalCount { get; set; }
    }
}
