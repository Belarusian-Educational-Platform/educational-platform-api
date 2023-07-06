using educational_platform_api.Contexts;
using educational_platform_api.Repositories;
using educational_platform_api.Services;
using Microsoft.EntityFrameworkCore;
using educational_platform_api.Queries;
using educational_platform_api.Mutations;
using educational_platform_api.Filters;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var AllowOrigins = "_allowOrigins";

// DB context setup
builder.Services.AddPooledDbContextFactory<MySQLContext>(options => {
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
    //Error Filters
    .AddErrorFilter<ProfileErrorFilter>()
    .AddErrorFilter<GroupErrorFilter>()
    .AddErrorFilter<OrganizationErrorFilter>()
    .AddErrorFilter<SubgroupErrorFilter>()
    // Queries
    .AddTypeExtension<ProfileQuery>()
    .AddTypeExtension<GroupQuery>()
    .AddTypeExtension<SubgroupQuery>()
    .AddTypeExtension<OrganizationQuery>()
    // Mutations
    .AddTypeExtension<ProfileMutation>()
    .AddTypeExtension<GroupMutation>()
    .AddTypeExtension<SubgroupMutation>()
    .AddTypeExtension<OrganizationMutation>();

// Services
builder.Services
    .AddScoped<IProfileService, ProfileService>()
    .AddScoped<IGroupService, GroupService>()
    .AddScoped<ISubgroupService, SubgroupService>()
    .AddScoped<IOrganizationService, OrganizationService>();

// Repositories
builder.Services
    .AddTransient<IProfileRepository, ProfileRepository>()
    .AddTransient<IGroupRepository, GroupRepository>()
    .AddTransient<ISubgroupRepository, SubgroupRepository>()
    .AddTransient<IOrganizationRepository, OrganizationRepository>();

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
