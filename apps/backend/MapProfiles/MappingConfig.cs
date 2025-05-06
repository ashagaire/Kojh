using Kojh.DAL.Models;

namespace backend.MapProfiles
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            CompanyProfile.Configure();
            ItemProfile.Configure();
            AssociationProfile.Configure();
            LocationProfile.Configure();
        }
    }
}
