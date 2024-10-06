using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.IoC;
using System;
using UrbanFarming.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UrbanContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
    opt.UseLazyLoadingProxies();
});

//builder.Services.StartRegisterServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS",
                      policy =>
                      {
                          policy.WithOrigins("*")
                                .WithHeaders("*")
                                .WithMethods("*");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
