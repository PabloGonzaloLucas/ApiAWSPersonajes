using ApiAWSPersonajes.Data;
using ApiAWSPersonajes.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corsenabled", opt =>
{
    opt.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("AwsMysql");
builder.Services.AddTransient<RepositoryTelevision>();
builder.Services.AddDbContext<TelevisionContext>
    (opt=> opt.UseMySQL(connectionString));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.MapOpenApi();
app.MapScalarApiReference();
app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});

app.UseCors("corsenabled");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
