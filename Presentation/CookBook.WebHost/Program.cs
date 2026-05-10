using CookBook.Infrastructure;
using CookBook.Infrastructure.RepositoriesEF;
using CookBook.Domain.Repositories.Abstractions;
using CookBook.WebHost.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string for ApplicationDbContext is not configured.");
}

// Database
builder.Services.AddNpgsql<ApplicationDbContext>(connectionString, options =>
{
    options.MigrationsAssembly("CookBook.Infrastructure");
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CookBook API",
        Description = "API for managing recipes, chefs, and gourmets."
    });
});

// Repositories
builder.Services.AddScoped<IChefRepository, ChefRepository>();
builder.Services.AddScoped<IGourmetRepository, GourmetRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase<ApplicationDbContext>();
app.Run();