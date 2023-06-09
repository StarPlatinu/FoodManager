using FoodManager.Model;
using FoodManager.Repository;
using FoodManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//Config appseting
builder.Services.AddDbContext<FoodManagerDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DBConnection")
    ));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<FoodManagerDBContext>();
//Dk repository cho container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Config urls to lower case
builder.Services.Configure<RouteOptions>(routeOptions => {
    routeOptions.LowercaseUrls = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.Run();
