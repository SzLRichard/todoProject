using Application.Context;
using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using todo.core.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("TodoDbConnectionString");

builder.ConfigureFunctionsWebApplication()
    .Services.AddDbContextFactory<TodoDBContext>(opt => opt.UseSqlServer(connectionString))
             .AddTransient<ITodoRepository, TodoRepository>()
             .AddTransient<ITodoService,TodoService>();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();


builder.Build().Run();
