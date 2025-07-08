using Microsoft.AspNetCore.Mvc;
using RenartCase.Dtos;
using RenartCase.Models;
using RenartCase.ServiceContracts;
using System.Text.Json;

namespace RenartCase.Controllers
{
    [ApiController]                           
    [Route("products")]                       
    public class ProductsController : ControllerBase  
    {
        private readonly IGoldService _gold;

        public ProductsController(IGoldService gold)
        {
            _gold = gold;
        }

        [HttpGet] // GET /products
        public async Task<IEnumerable<ProductResponseDto>> Get(
            [FromQuery] double? minPrice,
            [FromQuery] double? maxPrice,
            [FromQuery] double? minScore)
        {
            var json = await System.IO.File.ReadAllTextAsync("Data/products.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var products = JsonSerializer.Deserialize<List<Product>>(json, options)!; // 
            
            double goldPrice = await _gold.GetPricePerGramAsync();

            return products
                .Select(p => new ProductResponseDto
                {
                    Name = p.Name,
                    Weight = p.Weight,
                    Images = p.Images,
                    PopularityScore = p.PopularityScore,
                    PopularityOutOf5 = Math.Round(p.PopularityScore * 5, 1),
                    PriceUSD = Math.Round((p.PopularityScore + 1) * p.Weight * goldPrice, 2)
                })
                .Where(p =>
                    (!minPrice.HasValue || p.PriceUSD >= minPrice) &&
                    (!maxPrice.HasValue || p.PriceUSD <= maxPrice) &&
                    (!minScore.HasValue || p.PopularityOutOf5 >= minScore))
                .ToList();
        }
    }
}
