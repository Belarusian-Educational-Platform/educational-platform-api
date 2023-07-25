using educational_platform_api.DTOs;
using educational_platform_api.Models;

namespace educational_platform_api.Mappers
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper() 
        {
            CreateMap<CreateProfileInput, Profile>()
                .ForMember(dest => dest.KeycloakId, opt => opt.MapFrom(src => ""));
            CreateMap<Profile, CreateProfileInput>();

            CreateMap<UpdateProfileInput, Profile>()
                .ReverseMap();
        }
    }
}
