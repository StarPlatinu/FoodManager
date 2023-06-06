using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RestaurantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
