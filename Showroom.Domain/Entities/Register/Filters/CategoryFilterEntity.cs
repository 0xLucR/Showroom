using Showroom.Domain.Entities.Commom.Filters;

namespace Showroom.Domain.Entities.Register.Filters
{
    public class CategoryFilterEntity : BaseFilterEntity
    {
        public string? Name { get; set; }
    }
}