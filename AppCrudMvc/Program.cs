//esto es el punto de entrada de la aplicacion
//aqui se configura el servidor web y los servicios que se van a utilizar
using AppCrudMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//antes de que la aplicacion se inicie debo configurar el servicio de la base de datos
//esto me permite inyectar el contexto de la base de datos en los controladores
//luego de esto voy a la carpeta Data AppDBContext.cs
builder.Services.AddDbContext<AppDBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
