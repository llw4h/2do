using Microsoft.EntityFrameworkCore;
using ToDo.Models.EF;
using Microsoft.AspNetCore.Identity;
using ToDo.Data;
using ToDo.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Dependency injection for DbContext
builder.Services.AddDbContext<TodolistDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

 /**builder.Services.AddDefaultIdentity<ToDoUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthDbContext>();**/

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todolist}/{action=Index}/{id?}");

app.Run();
