namespace ProductManagement.Application.DTOs.Products
{
    public class ProductToCreateDto
    {
        public string? Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
