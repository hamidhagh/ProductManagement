using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Common.DTOs
{
    public class ProductDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ProduceDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
        public string? UserId { get; set; }
    }
}
