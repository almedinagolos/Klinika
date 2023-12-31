using FluentValidation.AspNetCore;
using Klinika.DB;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
builder.Services.AddFluentValidation(options =>
 {
     // Validate child properties and root collection elements
     options.ImplicitlyValidateChildProperties = true;
     options.ImplicitlyValidateRootCollectionElements = true;

     // Automatic registration of validators in assembly
     options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
