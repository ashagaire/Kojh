namespace backend.Features.CompanyFeature.Response
{
    public class CompanyResponse
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

        public SocialMediaResponse? SocialMedia { get; set; }
        public List<CompanyAssociationResponse> Memberships { get; set; } = [];
        public List<CompanyLocationResponse> Locations { get; set; } = [];


        public CompanyLogoResponse? Logo { get; set; }
    }

    public class SocialMediaResponse
    {
        public string Facebook { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Youtube { get; set; } = string.Empty;
    }

    public class CompanyAssociationResponse
    {
        public Guid Id { get; set; }

        public Guid AssociationId { get; set; }
        public string AssociationName { get; set; } = string.Empty;

        public AssociationLogoResponse? AssociationLogo { get; set; }


    }

    public class CompanyLocationResponse
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; } = string.Empty;

    }

    public class CompanyLogoResponse
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = string.Empty;
    }

    public class AssociationLogoResponse
    {
        public string Image { get; set; } = string.Empty;
    }
}
