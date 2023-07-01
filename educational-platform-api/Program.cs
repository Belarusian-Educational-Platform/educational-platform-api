using educational_platform_api.Contexts;
using educational_platform_api.Repositories;
using educational_platform_api.Services;
using Microsoft.EntityFrameworkCore;
using educational_platform_api.Queries;
using educational_platform_api.Mutations;

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
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<MySQLContext>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    // Queries
    .AddTypeExtension<UserQuery>()
    .AddTypeExtension<GroupQuery>()
    .AddTypeExtension<SubgroupQuery>()
    .AddTypeExtension<OrganizationQuery>()
    // Mutations
    .AddTypeExtension<UserMutation>()
    .AddTypeExtension<GroupMutation>()
    .AddTypeExtension<SubgroupMutation>()
    .AddTypeExtension<OrganizationMutation>();

// Services
builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IGroupService, GroupService>()
    .AddScoped<ISubgroupService, SubgroupService>()
    .AddScoped<IOrganizationService, OrganizationService>();

// Repositories
builder.Services
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IGroupRepository, GroupRepository>()
    .AddScoped<ISubgroupRepository, SubgroupRepository>()
    .AddScoped<IOrganizationRepository, OrganizationRepository>();

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
