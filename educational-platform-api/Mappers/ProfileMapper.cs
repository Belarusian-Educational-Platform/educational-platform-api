using educational_platform_api.DTOs.Profile;
using educational_platform_api.Models;
using System.Globalization;

namespace educational_platform_api.Mappers
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper() 
        {
            CreateMap<CreateProfileInput, Profile>()
                .ForMember(dest => dest.KeycloakId, opt => opt.MapFrom(src => ""))
                .ForMember(dest => dest.Birthday,
                    opt => opt.MapFrom(src =>
                        DateTime.ParseExact(src.Birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            CreateMap<UpdateProfileInput, Profile>()
                .ForMember(dest => dest.Birthday,
                    opt => opt.MapFrom(src => 
                        DateTime.ParseExact(src.Birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
