using System.Text.Json.Serialization;

namespace Laptopshopping.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? Ram { get; set; }
        public int? Storage { get; set; }

        public Decimal Price { get; set; }
        public string imageurl {  get; set; }
        public int? CategoryId { get; set; }
        
        public Category? Category { get; set; }
        

    }
}
