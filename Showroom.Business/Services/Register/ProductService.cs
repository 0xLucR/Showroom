using Showroom.Domain.Contracts.Repositories;
using Showroom.Domain.Contracts.Repositories.Register;
using Showroom.Domain.Contracts.Services.Register;
using Showroom.Domain.Entities.Register;
using Showroom.Domain.Entities.Register.Filters;

namespace Showroom.Business.Services.Register
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public void Add(ProductEntity entity)
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

        public ProductEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<ProductEntity> GetAll(ProductFilterEntity filter)
        {
            var query = _repository.GetAll();
            query = GetFilterCriterios(query, filter);

            return query.ToList();
        }

        private IQueryable<ProductEntity> GetFilterCriterios(IQueryable<ProductEntity> query, ProductFilterEntity filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(x => x.Name.Contains(filter.Name));

            if (filter.PriceInitial > 0)
                query = query.Where(x => x.Price >= filter.PriceInitial);

            if (filter.PriceFinal > 0)
                query = query.Where(x => x.Price <= filter.PriceFinal);

            return query;
        }

        public void Update(ProductEntity entity)
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