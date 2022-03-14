using Showroom.Domain.Contracts.Repositories;
using Showroom.Domain.Contracts.Repositories.Register;
using Showroom.Domain.Contracts.Services.Register;
using Showroom.Domain.Entities.Register;
using Showroom.Domain.Entities.Register.Filters;

namespace Showroom.Business.Services.Register
{
    public class CategoryService : ApplicationService, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public void Add(CategoryEntity entity)
        {
            _repository.Add(entity);

            //TODO: VALIDATIONS AND NOTIFICATIONS

            try
            {
                Commit();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public CategoryEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<CategoryEntity> GetAll(CategoryFilterEntity filter)
        {
            var query = _repository.GetAll();
            query = GetFilterCriterios(query, filter);

            return query.ToList();
        }

        private IQueryable<CategoryEntity> GetFilterCriterios(IQueryable<CategoryEntity> query, CategoryFilterEntity filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(x => x.Name.Contains(filter.Name));

            return query;
        }

        public void Update(CategoryEntity entity)
        {
            _repository.Update(entity);

            //TODO: VALIDATIONS AND NOTIFICATIONS

            try
            {
                Commit();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}