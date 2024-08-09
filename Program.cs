using Microsoft.EntityFrameworkCore;
using proyecto_final_prog2.Application;
using proyecto_final_prog2.Application.Services;
using proyecto_final_prog2.Infrastructure;
using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options => {
    options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")
    );
});
builder.Services.AddScoped<ColumnService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddRefitClient<IApiClient>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https://localhost:7052/");
    client.DefaultRequestHeaders.UserAgent.ParseAdd("internal");
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
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

app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
           //.WithOrigins("https://localhost:7158")); // Allow only this origin can also have multiple origins seperated with comma
           .SetIsOriginAllowed(origin => true));// Allow any origin  

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
