using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace backend.Features.CompanyFeature.Request
{
    public class SocialMediaRequest
    {
        public string Facebook { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Youtube { get; set; } = string.Empty;
    }

    public class CompanyLogoRequest
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = string.Empty;
    }

    public class NewCompany
    {
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
        public List<Guid> Memberships { get; set; } = [];
        public List<Guid> Locations { get; set; } = [];

        public SocialMediaRequest? SocialMedia { get; set; }
        public CompanyLogoRequest? Logo { get; set; }

    }
    public class AddCompanyRequest
    {
        [Required, FromBody] public NewCompany Body { get; set; } = new();

    }
}
