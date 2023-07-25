using Microsoft.EntityFrameworkCore;
using educational_platform_api.Extensions.Services;
using Keycloak.AuthServices.Authentication;

var builder = WebApplication.CreateBuilder(args);

var AllowOrigins = "_allowOrigins";

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

var authenticationOptions = builder.Configuration
    .GetSection(KeycloakAuthenticationOptions.Section)
    .Get<KeycloakAuthenticationOptions>()!;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context
builder.Services.AddDbContext(dbConnectionString);

// Keycloak
builder.Services.SetupKeycloak(authenticationOptions);

// Profile authorization
builder.Services.SetupProfileAuthorization();

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
builder.Services.AddValidators();

// Auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
