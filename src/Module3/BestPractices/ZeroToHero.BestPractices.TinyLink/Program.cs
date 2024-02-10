using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZeroToHero.BestPractices.TinyLink.Infrastructure;
using ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories;
using ZeroToHero.BestPractices.TinyLink.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
var directory = Directory.GetParent("..\\..\\..\\TinyLinkDB.db");
builder.Services.AddDbContext<TinyLinkDatabase>(options => options.UseSqlite(cs));

builder.Services.AddScoped<ITinyLinkRepository, TinyLinkRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<ITinyLinkService, TinyLinkService>();    

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
