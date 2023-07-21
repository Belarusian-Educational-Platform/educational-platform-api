using educational_platform_api.Contexts;
using educational_platform_api.Filters;
using educational_platform_api.Mutations;
using educational_platform_api.Queries;
using HotChocolate.Execution.Configuration;

namespace educational_platform_api.Extensions.Services
{
    public static class GraphQLServiceExtension
    {
        public static IRequestExecutorBuilder SetupGraphQLServer(this IServiceCollection services)
        {
            var requestExecutorBuilder = services.AddGraphQLServer()
                    .AddAuthorization()
                    .AddFiltering()
                    .AddSorting()
                    .RegisterDbContext<MySQLContext>()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>();

            return requestExecutorBuilder;
        }

        public static IRequestExecutorBuilder AddErrorFilters(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            requestExecutorBuilder
                .AddErrorFilter<ProfileErrorFilter>()
                .AddErrorFilter<GroupErrorFilter>()
                .AddErrorFilter<OrganizationErrorFilter>()
                .AddErrorFilter<SubgroupErrorFilter>();

            return requestExecutorBuilder;
        }

        public static IRequestExecutorBuilder AddQueryTypeExtensions(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            requestExecutorBuilder
                .AddTypeExtension<ProfileQuery>()
                .AddTypeExtension<GroupQuery>()
                .AddTypeExtension<SubgroupQuery>()
                .AddTypeExtension<OrganizationQuery>();

            return requestExecutorBuilder;
        }

        public static IRequestExecutorBuilder AddMutationTypeExtensions(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            requestExecutorBuilder
                .AddTypeExtension<ProfileMutation>()
                .AddTypeExtension<GroupMutation>()
                .AddTypeExtension<SubgroupMutation>()
                .AddTypeExtension<OrganizationMutation>();

            return requestExecutorBuilder;
        }
    }
}
