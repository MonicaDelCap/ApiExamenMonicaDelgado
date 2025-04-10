using ApiExamenMonicaDelgado.Data;
using ApiExamenMonicaDelgado.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddDbContext<SeriesContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlAzure")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.MapOpenApi();

app.UseHttpsRedirection();
app.MapScalarApiReference();
//app.UseSwaggerUI(options =>
//{
//    options.RoutePrefix = "";
//    options.SwaggerEndpoint("/openapi/v1.json", "Api Monica");
//});

app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});
app.UseAuthorization();

app.MapControllers();

app.Run();
