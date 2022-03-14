using Showroom.Domain.Entities.Commom.Filters;

namespace Showroom.Domain.Entities.Commom.Contracts
{
    public interface IServiceBase<TEntity, in TFilterEntity>
        where TEntity : BaseEntity
        where TFilterEntity : BaseFilterEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        ICollection<TEntity> GetAll(TFilterEntity filter);
    }
}