using System.Text.Json.Serialization;

namespace Laptopshopping.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }

    }
}
