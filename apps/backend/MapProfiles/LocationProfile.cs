using backend.Features.CompanyFeature.Response;
using backend.Features.CompanyFeature.ServiceModels;
using Kojh.DAL.Models;
using Mapster;

namespace backend.MapProfiles
{
    public static class LocationProfile
    {
        public static void Configure()
        {
            // Location -> CompanyLocationServiceModel
            TypeAdapterConfig<Location, CompanyLocationServiceModel>
                .NewConfig();

            // CompanyLocationServiceModel -> CompanyLocationResponse
            TypeAdapterConfig<CompanyLocationServiceModel, CompanyLocationResponse>
                .NewConfig();
        }
    }
}
