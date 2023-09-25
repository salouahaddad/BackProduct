using app_productAPI.Data;
using app_productAPI.Interfaces.Manager;
using app_productAPI.models;
using app_productAPI.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace app_productAPI.Manager
{
    public class UserManager : CommonManager<User>, IUserManager
    {
        public UserManager(AppDbContext dbContext) : base(new UserRepository(dbContext))
        {
        }
        public User GetUserByEmailAndPassword(string email,string password)
        {
            return GetFirstOrDefault(x => x.Email == email && x.Password==password);
        }
    }
}
