﻿using backend.Features.Company.Response;

namespace backend.Features.Company.ServiceModels
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

        public SocialMediaResponse? SocialMedia { get; set; }
        public List<CompanyAssociationServiceModel> Memberships { get; set; } = [];
        public List<CompanyLocationServiceModel> Locations { get; set; } = [];

        public CompanyLogoResponse? Logo { get; set; }
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
