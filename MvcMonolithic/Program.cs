using MvcMonolithic.ApplicationServices;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.Models;
using MvcMonolithic.Models.Services.Contracts;
using MvcMonolithic.Models.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectDbContext>();

builder.Services.AddScoped<IPersonRepository,PersonRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IPersonApplicationService,PersonApplicationService>();
builder.Services.AddScoped<IProductApplicationService,ProductApplicationService>();

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
