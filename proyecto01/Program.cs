using Microsoft.EntityFrameworkCore;
using proyecto01;

var builder = WebApplication.CreateBuilder(args);


// Leer la cadena de conexi�n desde appsettings.json
var cadenaConexion = builder.Configuration.GetConnectionString("DefaultConnection");
// Configurar DbContext con esa cadena
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(cadenaConexion));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
