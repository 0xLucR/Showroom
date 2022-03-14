using Showroom.Domain.Entities.Commom.Contracts;
using Showroom.Domain.Entities.Register;
using Showroom.Domain.Entities.Register.Filters;

namespace Showroom.Domain.Contracts.Services.Register
{
    public interface IProductService : IServiceBase<ProductEntity, ProductFilterEntity>
    {

    }
}