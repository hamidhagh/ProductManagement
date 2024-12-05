namespace ProductManagement.Application.DTOs.Products
{
    public class ProductToUpdateDto
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
