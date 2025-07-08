# 1. SDK imajı ile build işlemi
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Projeyi kopyala ve restore et
COPY *.sln .
COPY RenartCase/*.csproj ./RenartCase/
RUN dotnet restore

# Tüm dosyaları kopyala ve publish et
COPY . .
WORKDIR /app/RenartCase
RUN dotnet publish -c Release -o out

# 2. Runtime imajı ile çalıştırılabilir hale getir
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/RenartCase/out .

# Uygulamayı başlat
ENTRYPOINT ["dotnet", "RenartCase.dll"]
