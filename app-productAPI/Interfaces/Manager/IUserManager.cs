using app_productAPI.models;
using EF.Core.Repository.Interface.Manager;

namespace app_productAPI.Interfaces.Manager
{
    public interface IUserManager : ICommonManager<User>
    {
        public User GetUserByEmailAndPassword(string email, string password);
    }
}
