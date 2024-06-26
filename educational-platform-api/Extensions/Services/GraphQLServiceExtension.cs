﻿using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.EntityFramework.Contexts;
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
