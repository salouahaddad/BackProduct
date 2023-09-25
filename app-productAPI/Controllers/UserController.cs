using app_productAPI.Interfaces.Manager;
using app_productAPI.Manager;
using app_productAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace app_productAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // AppDbContext DbContext;
        IUserManager UserManager;
        private IConfiguration config;
        //public ProductController(AppDbContext appDbContext) {
        //DbContext = appDbContext;
        //    Manager=new ProductManager(DbContext);
        //}

        public UserController(IConfiguration configuration,IUserManager manager)
        {
            UserManager = manager;
            config = configuration;
        }


        private string GenerateToken(User user)
        {
            var secritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(secritykey, SecurityAlgorithms.HmacSha256);

            var token=new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"],null,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public JsonResult AddUser(User user)
        {

            bool isSave = UserManager.Add(user);

            return new JsonResult(isSave); ;
        }

        [AllowAnonymous]
        [HttpPost("{email}/{password}")]
        public JsonResult GetUser(string email,string password)
        {
            var user= UserManager.GetUserByEmailAndPassword(email,password);
            IActionResult response = Unauthorized();
            if (user != null)
            {
                var token= GenerateToken(user);
                response = Ok(new { token=token });
            }
            return new JsonResult(response);
        }
    }
}
