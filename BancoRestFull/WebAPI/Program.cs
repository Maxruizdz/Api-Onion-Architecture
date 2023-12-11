using Application;
using Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared;
using WebAPI.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.by

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddSharedInFraestructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddApiVersioningExtensions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {

    c.SwaggerDoc("v1", new OpenApiInfo{Title="WebApi", Version="v1" });

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
app.UseErrorHandlingMiddleware();
app.MapControllers();


app.Run();
