using DataTable.BLL.Services;
using DataTable.DAL.Data;
using DataTable.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataTable.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add context
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Add services
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
