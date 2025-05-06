using backend.Features.Company.Response;
using backend.Features.Company.ServiceModels;
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
