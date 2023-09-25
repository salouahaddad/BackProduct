using app_productAPI.Data;
using app_productAPI.Interfaces.Manager;
using app_productAPI.models;
using app_productAPI.Repository;
using EF.Core.Repository.Manager;

namespace app_productAPI.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager(AppDbContext dbContext) : base(new ProductRepository(dbContext))
        {
        }

        public Product GetById(int id)
        {
            return GetFirstOrDefault(x=>x.Id==id);
        }
    }
}
