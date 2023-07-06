using educational_platform_api.Contexts;
using Microsoft.EntityFrameworkCore;
using educational_platform_api.Extensions.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var AllowOrigins = "_allowOrigins";

// Context
builder.Services.AddPooledDbContextFactory<MySQLContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// GraphQL setup
builder.Services
    .SetupGraphQLServer()
    .AddErrorFilters()
    .AddQueryTypeExtensions()
    .AddMutationTypeExtensions();
    
// Services & Repositories
builder.Services
    .AddServices()
    .AddRepositories();

// Validators

// CORS Policy
builder.Services.AddCors(p => p.AddPolicy(AllowOrigins, builder =>
{
    builder.WithOrigins("https://localhost:44413")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
