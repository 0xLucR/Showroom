using Microsoft.EntityFrameworkCore;
using Showroom.Domain.Contracts.Repositories.Register;
using Showroom.Domain.Entities.Register;
using Showroom.Persistence.Data;

namespace Showroom.Persistence.Repositories.Register
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShowroomDataContext _context;

        public CategoryRepository(ShowroomDataContext context)
        {
            _context = context;
        }

        public void Add(CategoryEntity entity)
        {
            try
            {
                _context.Categories.Add(entity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            var ret = _context.Categories;
            return ret;
        }

        public CategoryEntity GetById(int id)
        {
            var ret = _context.Categories
                .Include(c => c.Products)
                .SingleOrDefault(x => x.Id == id);
            return ret;
        }

        public void Update(CategoryEntity entity)
        {
            _context.Categories.Update(entity);
        }
    }
}