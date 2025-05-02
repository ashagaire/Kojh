using Kojh.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Features.Company.Response
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

        public Guid? SocialMediasId { get; set; }
        public  List<CompanyAssociationResponse> Memberships { get; set; } = [];
        public  List<CompanyLocationResponse> Locations { get; set; } = [];


        public CompanyLogo? Logo { get; set; }
    }

    public class CompanyAssociationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
       
    }

    public class CompanyLocationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
