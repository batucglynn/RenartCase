namespace RenartCase.Dtos
{
    public class ProductResponseDto
    {
        public string Name { get; set; } = default!;
        public double Weight { get; set; }
        public Dictionary<string, string> Images { get; set; } = new();

        public double PopularityScore { get; set; }    
        public double PopularityOutOf5 { get; set; }     
        public double PriceUSD { get; set; }     
    }
}
