using app_productAPI.Data;
using app_productAPI.Interfaces.Repository;
using app_productAPI.models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace app_productAPI.Repository
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
