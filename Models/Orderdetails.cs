using System.Text.Json.Serialization;

namespace Laptopshopping.Models
{
    public class Orderdetails

    {
        public int Id { get; set; }
        public string productName { get; set; }
        public int Quantity { get; set; }
        public decimal? price { get; set; }
        public int? Ram { get; set; }
        public int? Storage { get; set; }
        public int? UserId { get; set; }
       
        public User User { get; set; }
    }
}
