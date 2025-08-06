using Application.Mappings;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validation;
using FluentValidation;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using todo.core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("TodoDbConnectionString");

builder.Services.AddControllers();

builder.Services
    .AddDbContextFactory<TodoDBContext>(options => options.UseSqlServer(connectionString))
    .AddAutoMapper(cfg =>
    {
        cfg.AddProfile(new MappingProfile());
    })
    .AddValidatorsFromAssemblyContaining<CreateTodoItemValidator>()
    .AddValidatorsFromAssemblyContaining<UpdateTodoItemValidator>()
    .AddTransient<ITodoRepository, TodoRepository>()
    .AddTransient<ITodoService, TodoService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
