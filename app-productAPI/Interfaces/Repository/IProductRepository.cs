using app_productAPI.models;
using EF.Core.Repository.Interface.Repository;

namespace app_productAPI.Interfaces.Repository
{
    public interface IProductRepository:ICommonRepository<Product>
    {
    }
}
