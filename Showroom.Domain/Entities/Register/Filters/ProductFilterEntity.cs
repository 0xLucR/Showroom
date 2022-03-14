using Showroom.Domain.Entities.Commom.Filters;

namespace Showroom.Domain.Entities.Register.Filters
{
    public class ProductFilterEntity : BaseFilterEntity
    {
        public string? Name { get; set; }
        public int IdCategory { get; set; }
        public decimal PriceInitial { get; set; }
        public decimal PriceFinal { get; set; }
    }
}