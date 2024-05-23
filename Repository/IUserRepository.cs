using Microsoft.AspNetCore.Mvc;
using Laptopshopping.DTO;
using Laptopshopping.Models;
using Laptopshopping.Repository;

namespace Laptopshopping.Repostitory
{
    public interface IUserRepository
    {
        User GetById(int id);
        string Register(User user);
        IEnumerable<Category> GetCategory();
        User Update(int Id,User user); 
        List<Product> getprodutbycategoryId(int CategoryId); 
        string Login(UserLoginDto userLoginDto );

        User getUser(UserLoginDto userLoginDto);
        
        IEnumerable<Product> GetProdusts();

        void additems(Cartitems cartitems);
        IEnumerable<Cartitems> getcartitems(int userid);
        void deletecart(int userid);
        void addneworder(IEnumerable<Orderdetails> orderdetails);

        IEnumerable<User> getuserdetails();
    }
}
