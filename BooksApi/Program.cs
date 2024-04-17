using BooksApi.Core.Entities;
using BooksApi.Core.Utility;
using BooksApi.Features.Books.Mapping;
using BooksApi.Features.Books.Validators;
using BooksApi.Infrastructure.Contexts;
using BooksApi.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionString)
);

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(IdentityConstants.BearerScheme);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserBookRepository, UserBookRepository>();
builder.Services.AddScoped<IBookStatisticRepository, BookStatisticRepository>();
builder.Services.AddScoped<IAppDbContextInitializer, AppDbContextInitializer>();

builder.Services.AddAutoMapper(typeof(BookMapping));

builder.Services.AddValidatorsFromAssembly(typeof(AddBookCommandValidator).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddRazorPages();

var app = builder.Build();

var shouldSeed = app.Configuration.GetValue<bool>("SeedDatabase");

if (shouldSeed)
{
    using var scope = app.Services.CreateScope();
    var initializeService = scope.ServiceProvider.GetRequiredService<IAppDbContextInitializer>();
    await initializeService.SeedDatabase();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
