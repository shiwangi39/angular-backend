using AutoMapper;
using Laptopshopping.DTO;
using Laptopshopping.Models;

namespace Laptopshopping.Map
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User,UserLoginDto>().ReverseMap();
            CreateMap<Admin, AdminLoginDto>().ReverseMap();
            CreateMap<OrderdetailsDto,Orderdetails>().ReverseMap();
        }
    }
}
