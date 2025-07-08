namespace RenartCase.Models
{
    public class Product
    {
        public string Name { get; set; } = default!;
        public double PopularityScore { get; set; }     // 0-1 arası
        public double Weight { get; set; }              // gram
        public Dictionary<string, string> Images { get; set; } = new();
    }
}
