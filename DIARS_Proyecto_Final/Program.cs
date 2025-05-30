using DIARS_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;
using DIARS_Proyecto_Final.Repositories;
using DIARS_Proyecto_Final.Repositories.Interfaces;
using DIARS_Proyecto_Final.Services;
using DIARS_Proyecto_Final.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar el DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) Registrar repositorios
builder.Services.AddScoped<IContratoEquipoRepository, ContratoEquipoRepository>();
builder.Services.AddScoped<IEquipoRepository, EquipoRepository>();
//// (y el resto de tus repositorios...)

//// 3) Registrar servicios
builder.Services.AddScoped<IContratoEquipoService, ContratoEquipoService>();
builder.Services.AddScoped<IEquipoService, EquipoService>();

// (y los demás servicios que hayas creado)

// 4) Añadir soporte a MVC con Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware habitual
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Ruta por defecto: por ejemplo a Equipo/Administrar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleado}/{action=MostrarEmpleados}/{id?}");

app.Run();
// En Program.cs o Startup.cs
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information));