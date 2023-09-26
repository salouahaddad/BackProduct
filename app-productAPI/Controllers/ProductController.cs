using app_productAPI.Data;
using app_productAPI.Interfaces.Manager;
using app_productAPI.Manager;
using app_productAPI.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace app_productAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // AppDbContext DbContext;
        IProductManager ProductManager;

        //public ProductController(AppDbContext appDbContext) {
        //DbContext = appDbContext;
        //    Manager=new ProductManager(DbContext);
        //}

        public ProductController(IProductManager manager)
        {
            ProductManager = manager;
        }

        [Authorize]
        [HttpGet]
  
       public JsonResult GetProducts()
        {
            var list= ProductManager.GetAll().ToList();
            return new JsonResult(list);
        }

        [Authorize]
        [HttpPost]
  
        public JsonResult AddProducts(Product newProduct)
        {
            
            bool isSave = ProductManager.Add(newProduct);
            
            return new JsonResult(isSave); ;
        }

        [Authorize]
        [HttpDelete("id")]
        public JsonResult DeleteProducts(int id)
        {
            Product product = ProductManager.GetById(id);
            if(product == null)
            {
                throw new Exception();
            }
           bool isDelete= ProductManager.Delete(product);

            return new JsonResult(isDelete); ;
        }

        }
}
