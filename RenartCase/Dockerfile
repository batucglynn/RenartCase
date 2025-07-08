# ----------- BUILD AŞAMASI -----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projeyi kopyala
COPY *.csproj ./
RUN dotnet restore

# Diğer tüm dosyaları kopyala ve build et
COPY . . 
RUN dotnet publish -c Release -o /app/publish

# ----------- RUNTIME AŞAMASI -----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "RenartCase.dll"]
