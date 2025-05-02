using backend.Features.Company.Response;
using backend.Features.Company.ServiceModels;
using backend.Features.ItemFeatures.Response;
using Kojh.DAL.Models;
using Mapster;

namespace backend.MapProfiles
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Item, ItemResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price);

            TypeAdapterConfig<ItemResponse, Item>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price);


            //TypeAdapterConfig<CompanyServiceModel, CompanyResponse>
            //    .NewConfig()
            //    .Map(dest => dest.Id, src => src.Id)
            //    .Map(dest => dest.Name, src => src.Name)
            //    .Map(dest => dest.HomePage, src => src.HomePage)
            //    .Map(dest => dest.MainAddress, src => src.MainAddress);

            //TypeAdapterConfig<Company, CompanyServiceModel>
            //    .NewConfig()
            //    .Map(dest => dest.Id, src => src.Id)
            //    .Map(dest => dest.Name, src => src.Name)
            //    .Map(dest => dest.HomePage, src => src.HomePage)
            //    .Map(dest => dest.MainAddress, src => src.MainAddress);
            // Company -> CompanyServiceModel
            TypeAdapterConfig<Company, CompanyServiceModel>
                .NewConfig()
                .Map(dest => dest.Memberships, src => src.Memberships.Select(m => m.Association))
                .Map(dest => dest.Locations, src => src.Locations.Select(l => l.Location));

            // CompanyServiceModel -> CompanyResponse
            TypeAdapterConfig<CompanyServiceModel, CompanyResponse>
                .NewConfig();

            // Association -> CompanyAssociationServiceModel
            TypeAdapterConfig<Association, CompanyAssociationServiceModel>
                .NewConfig();

            // CompanyAssociationServiceModel -> CompanyAssociationResponse
            TypeAdapterConfig<CompanyAssociationServiceModel, CompanyAssociationResponse>
                .NewConfig();

            // Location -> CompanyLocationServiceModel
            TypeAdapterConfig<Location, CompanyLocationServiceModel>
                .NewConfig();

            // CompanyLocationServiceModel -> CompanyLocationResponse
            TypeAdapterConfig<CompanyLocationServiceModel, CompanyLocationResponse>
                .NewConfig();

        }
    }
}
