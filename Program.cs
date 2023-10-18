using Microsoft.EntityFrameworkCore;
using ProcurementProcess.Net6.Context;
using ProcurementProcess.Net6.Interfaces;
using ProcurementProcess.Net6.Models;
using ProcurementProcess.Net6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IGenericInterface<RequestStatus>, GenericService<RequestStatus>>();
builder.Services.AddTransient<IGenericInterface<Vendor>, GenericService<Vendor>>();
builder.Services.AddTransient<IGenericInterface<Department>, GenericService<Department>>();
builder.Services.AddTransient<IGenericInterface<Request>, GenericService<Request>>();
builder.Services.AddTransient<ISpecificInterface, SpecificService>();


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
