using backend.Features.CompanyFeature.Response;
using backend.Features.CompanyFeature.ServiceModels;
using Kojh.DAL.Models;
using Mapster;

namespace backend.MapProfiles
{
    public static class AssociationProfile
    {
        public static void Configure()
        {
            // Association -> CompanyAssociationServiceModel
            TypeAdapterConfig<Association, CompanyAssociationServiceModel>
                .NewConfig()
                .Map(dest => dest.AssociationId, src => src.Id)
                .Map(dest => dest.AssociationName, src => src.Name)
                .Map(dest => dest.AssociationLogo, src => src.Logo); ;

            // CompanyAssociationServiceModel -> CompanyAssociationResponse
            TypeAdapterConfig<CompanyAssociationServiceModel, CompanyAssociationResponse>
                .NewConfig();

            TypeAdapterConfig<AssociationLogo, AssociationLogoResponse>.NewConfig();
        }
    }
}
