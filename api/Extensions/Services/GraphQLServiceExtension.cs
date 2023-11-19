using AppAny.HotChocolate.FluentValidation;
using api.EntityFramework.Contexts;
using api.Filters;
using api.Mutations;
using api.Queries;
using HotChocolate.Execution.Configuration;

namespace api.Extensions.Services
{
    public static class GraphQLServiceExtension
    {
        public static IRequestExecutorBuilder SetupGraphQLServer(this IServiceCollection services)
        {
            var requestExecutorBuilder = services.AddGraphQLServer()
                    .AddFluentValidation()
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
                .AddErrorFilter<ErrorWithNullExceptionFilter>()
                .AddErrorFilter<BusinessLogicErrorFilter>()
                .AddErrorFilter<ProfileAuthorizationErrorFilter>()
                .AddErrorFilter<RepositoryErrorFilter>();

            return requestExecutorBuilder;
        }

        public static IRequestExecutorBuilder AddQueryTypeExtensions(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            requestExecutorBuilder
                .AddTypeExtension<ProfileQuery>()
                .AddTypeExtension<GroupQuery>()
                .AddTypeExtension<OrganizationQuery>();

            return requestExecutorBuilder;
        }

        public static IRequestExecutorBuilder AddMutationTypeExtensions(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            requestExecutorBuilder
                .AddTypeExtension<ProfileMutation>()
                .AddTypeExtension<GroupMutation>()
                .AddTypeExtension<OrganizationMutation>();

            return requestExecutorBuilder;
        }
    }
}
