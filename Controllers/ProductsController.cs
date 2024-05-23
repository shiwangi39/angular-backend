using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Laptopshopping.DTO;
using Laptopshopping.Models;
using Laptopshopping.Repository;
using Laptopshopping.Repostitory;

namespace Mobilesshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetUsers()
        {
            var Hello = _productRepository.GetUsers();
            return Ok(Hello);
        }
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] AdminLoginDto adminLoginDto)
        {
            var log = _productRepository.Login(adminLoginDto);
            return Ok(log);
        }

        [HttpPost("[action]")]

        public IActionResult addproducts([FromBody] Product product)
        {
            _productRepository.AddProducts(product);
            return Ok();
        }
        [HttpPost("[action]")]

        public IActionResult addOrder([FromBody] Orderdetails orderdetails)
        {
            _productRepository.AddOrder(orderdetails);
            return Ok();
        }

        [HttpPut("[action]/{Id}")]

        public IActionResult UpdateProducts(int Id, [FromBody] Product product)
        {
            _productRepository.UpdateProducts(Id, product);
            return Ok();
        }


        [HttpGet("[action]")]
        [Authorize]
        public List<Product> GetProduct()
        {
            var log = _productRepository.GetProdusts();
            return log.ToList();
        }
        [HttpGet("[action]")]
        public List<Orderdetails> GetOrderdetails()
        {
            var srh = _productRepository.GetOrderDetails();
            return srh.ToList();
        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteProduct(int Id)
        {
            _productRepository.DeleteProducts(Id);
            return Ok();
        }

        [HttpGet("[action]")]
        public List<Orderdetails> Getorderdetailsbyuserid(int userid)
        {
            var srh = _productRepository.getorderdetailsbyid(userid);    
            return srh.ToList();
        }
    }
}
