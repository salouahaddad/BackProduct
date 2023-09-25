using app_productAPI.Data;
using app_productAPI.Interfaces.Repository;
using app_productAPI.models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace app_productAPI.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
