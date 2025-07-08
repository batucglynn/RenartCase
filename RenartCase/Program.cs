using RenartCase.ServiceContracts;
using RenartCase.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor view + API + Swagger + CORS
builder.Services.AddControllersWithViews();    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IGoldService, GoldService>(); 

var app = builder.Build();

// Swagger sadece dev ortamda aktif olsun
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();                         

app.UseRouting();

app.UseAuthorization();


app.MapControllers();
app.MapDefaultControllerRoute();             

app.Run();
