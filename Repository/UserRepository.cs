using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Laptopshopping.Data;
using Laptopshopping.DTO;
using Laptopshopping.Models;
using Laptopshopping.Repostitory;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Security;
using System.Security.Claims;
using System.Text;

namespace Laptopshopping.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration config)
        {
            _config = config;
        }
        AppDbContext _dbContext = new AppDbContext();
       

        public User GetById(int id)
        {
            var userexist = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return userexist;
        }
        public string Register(User user)
        {
            var ind = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if(ind == null)                                                                                                      
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return "registerd";
            }
            else
            {
                return "invalid";
            }
             
        }

        public User Update(int Id,User user)
        { 
            var newone = _dbContext.Users.FirstOrDefault(u=>u.Id==user.Id);
            if (newone == null)
            {
                return null;
            }
            newone.Name = user.Name;
            newone.Email = user.Email;
            newone.Password = user.Password;
            newone.Phone = user.Phone;
            newone.City = user.City;
            _dbContext.SaveChanges();
            return newone;
                
        }

        public string Login(UserLoginDto userLoginDto)
        {
            var log = _dbContext.Users.FirstOrDefault(u => u.Email == userLoginDto.Email && u.Password == userLoginDto.Password);
            if (log == null)
            {
                return ("invaild");
            }
            else
            {
                var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                var credential = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
                var Claims = new[]
                {
                new Claim(ClaimTypes.Email,userLoginDto.Email)
            };
                var token = new JwtSecurityToken(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    signingCredentials: credential,
                    claims: Claims,
                    expires: DateTime.Now.AddMinutes(60));
                var Jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return (Jwt);
            };
        }

        public IEnumerable<Product> GetProdusts()
        {
            var data = _dbContext.Products;
            return data;
        }

        public IEnumerable<Category> GetCategory()
        {
            var category = _dbContext.Categories;
            return category;

        }

        public List<Product> getprodutbycategoryId(int CategoryId)
        {
            var exist = _dbContext.Products.Where(p => p.CategoryId == CategoryId);
            return exist.ToList();
        }

        public User getUser(UserLoginDto userLoginDto)
        {
            var data = _dbContext.Users.FirstOrDefault(u => u.Email == userLoginDto.Email && u.Password == userLoginDto.Password);
            return data;
        }

        public void additems(Cartitems cartitems)
        {
            
            _dbContext.Cartitems.Add(cartitems);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Cartitems> getcartitems(int userid)
        {
            var hello = _dbContext.Cartitems.Where(cd => cd.UserId == userid);
            return hello;
           
        }

        public void deletecart(int userid)
        {
            var dele = _dbContext.Cartitems.Where(od => od.UserId == userid);
            if (dele != null)
            {
                _dbContext.Cartitems.RemoveRange(dele);
                _dbContext.SaveChanges();

            }
        }

        public void addneworder(IEnumerable<Orderdetails> orderdetails)
        {
            var orders = new List<Orderdetails>();
            foreach (var orderdetail in orderdetails)
            {
                orders.Add(orderdetail);
            }

            // Add the orders to the database
            _dbContext.OrderDetails.AddRange(orders);
             _dbContext.SaveChanges();
        }

        public IEnumerable<User> getuserdetails()
        {
            var srh = _dbContext.Users;
            return srh;
        }
    }
}
