using Showroom.Domain.Entities.Commom;

namespace Showroom.Domain.Entities.Register
{
    public class CategoryEntity : BaseEntity
    {
        public CategoryEntity(string name, string description)
        {
            Name = name;
            Description = description;
            Products = new List<ProductEntity>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<ProductEntity> Products { get; private set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }

        //TODO: Validate

    }
}