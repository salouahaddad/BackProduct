using Microsoft.AspNetCore.Mvc.ApplicationModels;
using EF.Core.Repository.Interface.Manager;
using app_productAPI.models;

namespace app_productAPI.Interfaces.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {

        public Product GetById(int id);
    }
}
