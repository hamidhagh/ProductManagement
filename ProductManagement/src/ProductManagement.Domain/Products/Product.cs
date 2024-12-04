using ProductManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
