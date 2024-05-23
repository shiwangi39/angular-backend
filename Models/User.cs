
using System.ComponentModel.DataAnnotations;

namespace Laptopshopping.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [RegularExpression(@"[a-z]+[0-9]*@[a-z]+.com")]
        public string Email { get; set; }

        public string Password { get; set; }
        [StringLength(10)]
        [RegularExpression(@"[0-9]*$")]
        public string? Phone { get; set; }
        public string? City { get; set; }
    }
}
