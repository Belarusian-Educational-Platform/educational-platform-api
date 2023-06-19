using educational_platform_api.Contexts;
using educational_platform_api.Repositories;
using educational_platform_api.Services;
using Microsoft.EntityFrameworkCore;
using educational_platform_api.Queries;
using educational_platform_api.Mutations;
using educational_platform_api.Filters;

var builder = WebApplication.CreateBuilder(args);

var AllowOrigins = "_allowOrigins";

// DB context setup
builder.Services.AddDbContext<MySQLContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// GraphQL setup
builder.Services
    .AddGraphQLServer()
    .AddErrorFilter<GlobalErrorFilter>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<UserQuery>()
    .AddTypeExtension<UserMutation>();
    

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ISubgroupRepository, SubgroupRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ISubgroupService, SubgroupService>();

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

// Configure the HTTP request pipeline.
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
