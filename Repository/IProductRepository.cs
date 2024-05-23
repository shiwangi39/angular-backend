using Microsoft.AspNetCore.Mvc;
using Laptopshopping.DTO;
using Laptopshopping.Models;

namespace Laptopshopping.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Orderdetails> GetOrderDetails();
        Product GetById(int id);
        void AddProducts(Product product);
        void AddOrder(Orderdetails orderdetails);
        IEnumerable<Product> GetProdusts();

        Product UpdateProducts(int Id,Product product);
        string Login(AdminLoginDto adminLoginDto);
        Product DeleteProducts(int Id);
        IEnumerable<User> GetUsers();
        List<Orderdetails> getorderdetailsbyid(int userid);
    }
}
