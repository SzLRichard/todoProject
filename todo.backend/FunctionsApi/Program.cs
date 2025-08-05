using Application.Mappings;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validation;
using FluentValidation;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using todo.core.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("TodoDbConnectionString");

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



builder.ConfigureFunctionsWebApplication();
// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();


builder.Build().Run();
