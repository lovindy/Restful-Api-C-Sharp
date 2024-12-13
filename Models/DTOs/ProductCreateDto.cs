// Models/DTOs/ProductCreateDto.cs
namespace MyRestApi.Models.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}