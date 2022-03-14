using Showroom.Domain.Entities.Commom;

namespace Showroom.Domain.Entities.Register
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(int idCategory, string name, string description, decimal price)
        {
            IdCategory = idCategory;
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public int IdCategory { get; private set; }

        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}