using Laptopshopping.Models;
using System.Text.Json.Serialization;

namespace Laptopshopping.DTO
{
    public class OrderdetailsDto
    {

        public string mobileName { get; set; }
        public int Quantity { get; set; }
        public decimal? price { get; set; }
        public int? Ram { get; set; }
        public int? Storage { get; set; }
        public int? UserId { get; set; }
 
    }
}

