using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Laptopshopping.Data;
using Laptopshopping.DTO;
using Laptopshopping.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Laptopshopping.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _config;
        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }
        AppDbContext _dbContext = new AppDbContext();
        public IEnumerable<User> GetUsers()
        {
            var data = _dbContext.Users;
            return data;
        }
        public void AddProducts(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            
        }

        public IEnumerable<Product> GetAll()
        {
            var productdata = _dbContext.Products;
            return productdata;
        }

        public Product GetById(int id)
        {
            var Productexist = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            return Productexist;
        }

        public string Login(AdminLoginDto adminLoginDto)
        {
            var adminexist = _dbContext.Admins.FirstOrDefault(u => u.UserName == adminLoginDto.UserName && u.Password == adminLoginDto.Password);
            if(adminexist == null)
            {
                return ("invalid");
            }
            else
            {
                var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                var Credentials = new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);
                var Claims = new[]
               {
                new Claim(ClaimTypes.Email,adminLoginDto.UserName)
                };
                var token = new JwtSecurityToken(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: Claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: Credentials);
                var JWT = new JwtSecurityTokenHandler().WriteToken(token);
                return JWT;
            }
        }

        public Product UpdateProducts(int Id,Product product)
        {
            var hello = _dbContext.Products.Find(Id);
            if (hello == null)
            {
                return null;
            }
                hello.ProductName = product.ProductName;
                hello.ProductDescription = product.ProductDescription;
                hello.Price= product.Price;
                hello.CategoryId= product.CategoryId;
                hello.Ram= product.Ram;
                hello.Storage= product.Storage;
                _dbContext.SaveChanges();
                return hello;
        }

        public Product DeleteProducts(int Id)
        {

            var del = _dbContext.Products.Find(Id);
            if (del == null)
            {
                return (null);
            }
            _dbContext.Products.Remove(del);
            _dbContext.SaveChanges();
            return (del);
            
        }

        public IEnumerable<Product> GetProdusts()
        {
            var data = _dbContext.Products;
            return data;
        }

        public IEnumerable<Orderdetails> GetOrderDetails()
        {
            var data=_dbContext.OrderDetails;
            return data;
        }

        public void AddOrder(Orderdetails orderdetails)
        {
            _dbContext.OrderDetails.Add(orderdetails);
            _dbContext.SaveChanges();
        }

        public List<Orderdetails> getorderdetailsbyid(int userid)
        {
            return _dbContext.OrderDetails.Where(od => od.UserId == userid).ToList();
        }
    }
}
