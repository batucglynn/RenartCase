using System.Text.Json;
using RenartCase.ServiceContracts;

namespace RenartCase.Services;

public class GoldService : IGoldService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _cfg;

    private double _cachedPrice = 70.0;
    private DateTime _lastFetch = DateTime.MinValue;
    private const double GRAMS_PER_TROY_OUNCE = 31.1035;

    public GoldService(HttpClient http, IConfiguration cfg)
    {
        _http = http;
        _cfg = cfg;
    }

    public async Task<double> GetPricePerGramAsync()
    {
        if ((DateTime.UtcNow - _lastFetch).TotalMinutes < 10)
            return _cachedPrice;

        var apiKey = _cfg["MetalPriceApiKey"];
        var url = $"https://api.metalpriceapi.com/v1/latest?api_key={apiKey}&base=USD&currencies=XAU";

        try
        {
            var json = JsonDocument.Parse(await _http.GetStringAsync(url));
            double usdToXau = json.RootElement.GetProperty("rates").GetProperty("XAU").GetDouble();
            double usdPerOunc = 1 / usdToXau;
            _cachedPrice = Math.Round(usdPerOunc / GRAMS_PER_TROY_OUNCE, 2);
            _lastFetch = DateTime.UtcNow;
        }
        catch { }

        return _cachedPrice;
    }
}
