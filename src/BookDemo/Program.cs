using BookDemo.Adapter;
using BookDemo.Application;
using BookDemo.Infrastructure;

using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddAdapter();
builder.Services.AddApplication();

var app = builder.Build();

app.MapGraphQL();
app.Run();
