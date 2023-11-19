using api.Services;
using api.Validators;
using api.Validators.Group;
using api.Validators.Organization;
using api.Validators.Profile;
using api.Validators.Relations;
using FluentValidation.AspNetCore;

namespace api.Extensions.Services
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProfileService, ProfileService>()
                    .AddTransient<IGroupService, GroupService>()
                    .AddTransient<IOrganizationService, OrganizationService>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidation()
                //Account
                .AddScoped<AccountValidator>()
                // Profile
                .AddScoped<CreateProfileInputValidator>()
                .AddScoped<UpdateProfileInputValidator>()
                // Organization
                .AddScoped<CreateOrganizationInputValidator>()
                .AddScoped<UpdateOrganizationInputValidator>()
                // Group
                .AddScoped<CreateGroupInputValidator>()
                .AddScoped<UpdateGroupInputValidator>()
                // Relations
                .AddScoped<CreateProfileGroupRelationInputValidator>()
                .AddScoped<UpdateProfileGroupRelationInputValidator>()
                .AddScoped<UpdateProfileOrganizationRelationInputValidator>();
             
            return services;
        }
    }
}
