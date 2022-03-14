using Showroom.Domain.Contracts.Repositories.Register;
using Showroom.Domain.Entities.Register;
using Showroom.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Showroom.Persistence.Repositories.Register
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShowroomDataContext _context;

        public ProductRepository(ShowroomDataContext context)
        {
            _context = context;
        }

        public void Add(ProductEntity entity)
        {
            try
            {
                _context.Products.Add(entity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IQueryable<ProductEntity> GetAll()
        {
            var ret = _context.Products;
            return ret;
        }

        public ProductEntity GetById(int id)
        {
            return _context.Products
                .SingleOrDefault(x => x.Id == id);
        }

        public void Update(ProductEntity entity)
        {
            _context.Products.Update(entity);
        }
    }
}