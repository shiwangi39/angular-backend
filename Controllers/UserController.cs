using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laptopshopping.DTO;
using Laptopshopping.Models;
using Laptopshopping.Repostitory;

namespace Mobilesshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)           
        {
            var hi = _UserRepository.GetById(id);
            return Ok(hi);
        }
        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User user)
        {

            var hello = _UserRepository.Register(user);
            return Ok(hello);
        }
        [HttpPost("[action]")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var bye = _UserRepository.Login(userLoginDto);
            return Ok(bye);
        }
        [HttpPut("[action]/{id}")]
        public void Update(int id, [FromBody] User user)
        {
            _UserRepository.Update(id, user);
        }

        [HttpGet("[action]")]
        [Authorize]
        public List<Product> GetProduct()
        {
            var log = _UserRepository.GetProdusts();
            return log.ToList();
        }
        [HttpGet("[action]")]
        public IActionResult Getcategory()
        {
            var category = _UserRepository.GetCategory();
            return Ok(category);
        }
        [HttpGet("[action],{CategoryId}")]
        
        public IActionResult getproductbycategoryId(int CategoryId)
        {
            var pro = _UserRepository.getprodutbycategoryId(CategoryId);
            return Ok(pro);
        }
        [HttpPost("[action]")]
        public IActionResult getdata(UserLoginDto userLoginDto)
        {
            var bye = _UserRepository.getUser(userLoginDto);
            return Ok(bye);
        }
        [HttpPost("[action]")]

        public void additems([FromBody] Cartitems cartitems)
        {
            _UserRepository.additems(cartitems);

        }
        [HttpGet("[action],{userid}")]
        public List<Cartitems> GetCartitems(int userid)
        {
            var hello = _UserRepository.getcartitems(userid);
            return hello.ToList();
        }
        [HttpDelete("[action],{userid}")]
        public void deletecart(int userid)
        {
            _UserRepository.deletecart(userid);
           
            
        }
        [HttpPost("[action]")]

        public IActionResult addnewitem(IEnumerable<Orderdetails> orderdetails)
        {
            
            _UserRepository.addneworder(orderdetails);
            return Ok();
        }
        [HttpGet("[action]")]
        public List<User> getuserdetails()
        {
            var rr = _UserRepository.getuserdetails();
            return rr.ToList();
        }
    } 
}
