using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Features.CompanyFeature.Request
{
   
    public class UpdateCompanyDetails
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

    }
    public class UpdateCompanyDetailsRequest
    {
        [Required, FromRoute(Name = "id")] public Guid Id { get; set; }
        [Required, FromBody] public UpdateCompanyDetails Body { get; set; } = new();
    }
}
