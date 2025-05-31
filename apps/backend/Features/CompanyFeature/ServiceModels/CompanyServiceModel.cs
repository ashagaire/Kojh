using backend.Features.CompanyFeature.Response;
using Kojh.DAL.Models;

namespace backend.Features.CompanyFeature.ServiceModels
{
    public class CompanyServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string HomePage { get; set; } = string.Empty;
        public string GeneralEmailAddress { get; set; } = string.Empty;
        public string GeneralPhoneNumber { get; set; } = string.Empty;
        public string MainAddress { get; set; } = string.Empty;
        public int NumberOfEmployee { get; set; }
        public string Established { get; set; } = string.Empty;
        public string BusinessId { get; set; } = string.Empty;
        public string ContactPersonEmail { get; set; } = string.Empty;
        public string ConciseDescription { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;

        public SocialMediaServiceModel? SocialMedia { get; set; }
        public List<Guid> Memberships { get; set; } = [];
        public List<Guid> Locations { get; set; } = [];

        public CompanyLogoServiceModel? Logo { get; set; }

        public List<CompanyAssociationServiceModel> ExistingMemberships { get; set; } = [];
        public List<CompanyLocationServiceModel> ExistingLocations { get; set; } = [];
    }

    public class CompanyLogoServiceModel
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = string.Empty;
    }
    public class SocialMediaServiceModel
    {
        public string Facebook { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Youtube { get; set; } = string.Empty;
    }
    public class CompanyAssociationServiceModel
    {
        public Guid Id { get; set; }
        public Guid AssociationId { get; set; }
        public string AssociationName { get; set; } = string.Empty;
        public AssociationLogoResponse? AssociationLogo { get; set; }

    }

    public class CompanyLocationServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
