# ---------- BUILD AŞAMASI ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Çözüm ve projeyi kopyala
COPY . .
RUN dotnet publish RenartCase.csproj -c Release -o /app/publish

# ---------- RUNTIME AŞAMASI ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "RenartCase.dll"]
