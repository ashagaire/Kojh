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
        }
    }
}
