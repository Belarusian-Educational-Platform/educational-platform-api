using Microsoft.EntityFrameworkCore;
using api.Extensions.Services;
using Keycloak.AuthServices.Authentication;

var builder = WebApplication.CreateBuilder(args);

var CORSPolicy = "_corsPolicy";

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
    .AddProjections()
    .AddQueryTypeExtensions()
    .AddMutationTypeExtensions();

// Services
builder.Services.AddServices();

// Validators
builder.Services.AddValidators();

// Auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CORS Policy
builder.Services.AddCors(p => p.AddPolicy(CORSPolicy, builder =>
{
    builder.WithOrigins("http://localhost:3000")
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

app.UseCors(CORSPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
