using backend.Features.Company.Response;
using backend.Features.Company.ServiceModels;
using Kojh.DAL.Models;
using Mapster;

namespace backend.MapProfiles
{
    public static class CompanyProfile
    {
        public static void Configure()
        {
            // Company -> CompanyServiceModel
            TypeAdapterConfig<Company, CompanyServiceModel>
                .NewConfig()
                .Map(dest => dest.SocialMedia, src => src.SocialMedia)
                .Map(dest => dest.Memberships, src => src.Memberships.Select(m => m.Association))
                .Map(dest => dest.Locations, src => src.Locations.Select(l => l.Location))
                .Map(dest => dest.Logo, src => src.Logo);

            // CompanyServiceModel -> CompanyResponse
            TypeAdapterConfig<CompanyServiceModel, CompanyResponse>
                .NewConfig();

            TypeAdapterConfig<SocialMedia, SocialMediaResponse>.NewConfig();

            TypeAdapterConfig<Company, CompanyResponse>
                .NewConfig()
                .Map(dest => dest.SocialMedia, src => src.SocialMedia);

            TypeAdapterConfig<CompanyLogo, CompanyLogoResponse>.NewConfig();


        }
    }
}
