using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddSingleton<IDogRepository, DogRepository>();
// builder.Services.AddScoped<IDogRepository, DogRepository>();
builder.Services.AddTransient<IDogRepository, DogRepository>(); 
    
// builder.Services.AddScoped<IDogRepository, DogRepository>();
builder.Services.AddScoped<IDogService, DogService>();

builder.Services.AddMvc();
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

app.MapControllers();

// app.MapGet("/dogs", (IDogService dogService) =>
// {
//     return Results.Ok(dogService.FetchDogs());
// });

app.Run();