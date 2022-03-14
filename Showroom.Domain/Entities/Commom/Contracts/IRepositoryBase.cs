
namespace Showroom.Domain.Entities.Commom.Contracts
{
    public interface IRepositoryBase<TEntity>
        where TEntity : BaseEntity
    {

        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);

        //ICollection<Entity> Get(int skip, int take);

    }
}