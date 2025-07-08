# 📦 RenartCase – Product Listing Application

Bu proje, ürün listeleme uygulamasının .NET backend API ve sade bir HTML/JS frontend arayüzü ile geliştirilmiş halidir.

---

## 🛠 Teknolojiler

- ASP.NET Core Web API (.NET 8)
- Tailwind CSS (CDN)
- JavaScript (vanilla)
- Swiper.js (carousel için)
- MetalPriceAPI (gerçek zamanlı altın fiyatı verisi)

---

## 🚀 Başlatmak için

### Backend:

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/batucglynn/RenartCase.git
   ```

2. API anahtarınızı `appsettings.json` dosyasına ekleyin:
   ```json
   "MetalPriceApiKey": "YOUR_API_KEY_HERE"
   ```

3. Projeyi Visual Studio veya terminal ile başlatın:
   ```bash
   dotnet run
   ```

### Frontend:

- Proje çalıştığında `https://localhost:{port}/` adresine gidin.
- `/products` endpoint'inden ürün verileri gelir ve HTML sayfada listelenir.

---

## 💡 Özellikler

- Gerçek zamanlı altın fiyatına göre fiyat hesaplama  
- Carousel (kaydırılabilir ürün görselleri)  
- Renk seçimiyle ürün görseli değiştirme  
- Popülerlik puanını yıldızlarla gösterme  
- Responsive (mobil uyumlu) tasarım

---

## 🔗 API Örneği

```json
{
  "name": "Diamond Ring",
  "popularityScore": 85,
  "weight": 3.2,
  "images": {
    "#E6CA97": "yellow_gold.jpg",
    "#D9D9D9": "white_gold.jpg",
    "#E1A4A9": "rose_gold.jpg"
  }
}
```