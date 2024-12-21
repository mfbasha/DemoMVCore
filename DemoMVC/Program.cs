using System.Configuration;
using DemoMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var user_name=configuration["postgres-username"];
var password=configuration["postgres-password"];
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyAppContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
.Replace("{USERNAME}", user_name)
.Replace("{PASSWORD}", password),
 b => b.MigrationsAssembly("DemoMVC")));


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
    pattern: "{controller=Items}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
