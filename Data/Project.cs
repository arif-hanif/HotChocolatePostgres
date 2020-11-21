using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotChocolatePostgres.Data
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }

        [Column(TypeName = "jsonb")]
        public Customer? Customer { get; set; }

    }

    public class Customer    // Mapped to a JSON column in the table
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Order[]? Orders { get; set; }
    }

    public class Order       // Part of the JSON column
    {
        public decimal Price { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
