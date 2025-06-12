using backend.Features.CompanyFeature.Request;
using backend.Features.CompanyFeature.Response;
using backend.Features.CompanyFeature.ServiceModels;
using Kojh.DAL.Helpers;
using Kojh.DAL.Models;
using Mapster;

namespace backend.MapProfiles
{
    public static class CompanyProfile
    {
        public static void Configure()
        {
            // Company -> CompanyServiceModel

            TypeAdapterConfig<GetAllCompanyRequest, PaginatedCompanyServiceModel>.NewConfig();

            TypeAdapterConfig<PaginatedCompanyResponse, PaginatedCompanyServiceModel>.NewConfig();

            TypeAdapterConfig<PaginatedCompanyServiceModel, CompanyListFilter>.NewConfig();


            TypeAdapterConfig<AddCompanyRequest, CompanyServiceModel>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Body.Name)
                .Map(dest => dest.AccountType, src => src.Body.AccountType)
                .Map(dest => dest.HomePage, src => src.Body.HomePage)
                .Map(dest => dest.GeneralEmailAddress, src => src.Body.GeneralEmailAddress)
                .Map(dest => dest.GeneralPhoneNumber, src => src.Body.GeneralPhoneNumber)
                .Map(dest => dest.MainAddress, src => src.Body.MainAddress)
                .Map(dest => dest.NumberOfEmployee, src => src.Body.NumberOfEmployee)
                .Map(dest => dest.Established, src => src.Body.Established)
                .Map(dest => dest.BusinessId, src => src.Body.BusinessId)
                .Map(dest => dest.ContactPersonEmail, src => src.Body.ContactPersonEmail)
                .Map(dest => dest.ConciseDescription, src => src.Body.ConciseDescription)
                .Map(dest => dest.CompanyDescription, src => src.Body.CompanyDescription)
                .Map(dest => dest.SocialMedia, src => src.Body.SocialMedia)
                .Map(dest => dest.Memberships, src => src.Body.Memberships)
                .Map(dest => dest.Locations, src => src.Body.Locations)
                .Map(dest => dest.Logo, src => src.Body.Logo);

            TypeAdapterConfig<UpdateCompanyDetailsRequest, CompanyServiceModel>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Body.Name)
                .Map(dest => dest.AccountType, src => src.Body.AccountType)
                .Map(dest => dest.HomePage, src => src.Body.HomePage)
                .Map(dest => dest.GeneralEmailAddress, src => src.Body.GeneralEmailAddress)
                .Map(dest => dest.GeneralPhoneNumber, src => src.Body.GeneralPhoneNumber)
                .Map(dest => dest.MainAddress, src => src.Body.MainAddress)
                .Map(dest => dest.NumberOfEmployee, src => src.Body.NumberOfEmployee)
                .Map(dest => dest.Established, src => src.Body.Established)
                .Map(dest => dest.BusinessId, src => src.Body.BusinessId)
                .Map(dest => dest.ContactPersonEmail, src => src.Body.ContactPersonEmail)
                .Map(dest => dest.ConciseDescription, src => src.Body.ConciseDescription)
                .Map(dest => dest.CompanyDescription, src => src.Body.CompanyDescription);

            TypeAdapterConfig<CompanyServiceModel, Company>
                .NewConfig()
                .Map(dest => dest.SocialMedia, src => src.SocialMedia)
                .Map(dest => dest.Logo, src => src.Logo)
                .Ignore(dest => dest.Memberships)
                .Ignore(dest => dest.Locations);

            TypeAdapterConfig<Company, CompanyServiceModel>
                .NewConfig()
                .Map(dest => dest.SocialMedia, src => src.SocialMedia)
                .Map(dest => dest.ExistingMemberships, src => src.Memberships)
                .Map(dest => dest.ExistingLocations, src => src.Locations)
                .Map(dest => dest.Logo, src => src.Logo);

            TypeAdapterConfig<CompanyServiceModel, CompanyResponse>
                .NewConfig()
                .Map(dest => dest.SocialMedia, src => src.SocialMedia)
                .Map(dest => dest.Memberships, src => src.ExistingMemberships)
                .Map(dest => dest.Locations, src => src.ExistingLocations)
                .Map(dest => dest.Logo, src => src.Logo);



            // SocialMedia and Logo
            TypeAdapterConfig<SocialMediaServiceModel, SocialMediaResponse>.NewConfig();
            TypeAdapterConfig<SocialMedia, SocialMediaServiceModel>.NewConfig();
            TypeAdapterConfig<SocialMediaRequest, SocialMediaServiceModel>.NewConfig();

            TypeAdapterConfig<CompanyLogoRequest, CompanyLogoServiceModel>.NewConfig();
            TypeAdapterConfig<CompanyLogoServiceModel, CompanyLogoResponse>.NewConfig();
            TypeAdapterConfig<CompanyLogo, CompanyLogoResponse>.NewConfig();


            TypeAdapterConfig<IEnumerable<Association>, List<Guid>>.NewConfig()
                .MapWith(src => src.Select(a => a.Id).ToList());

            TypeAdapterConfig<IEnumerable<Location>, List<Guid>>.NewConfig()
                .MapWith(src => src.Select(l => l.Id).ToList());

            // Association <-> ServiceModel/Response
            TypeAdapterConfig<CompanyAssociation, CompanyAssociationServiceModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.AssociationId, src => src.AssociationId)
                .Map(dest => dest.AssociationName, src => src.Association.Name)
                .Map(dest => dest.AssociationLogo, src => src.Association.Logo);

            TypeAdapterConfig<CompanyAssociationServiceModel, CompanyAssociationResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.AssociationId, src => src.AssociationId)
                .Map(dest => dest.AssociationName, src => src.AssociationName)
                .Map(dest => dest.AssociationLogo, src => src.AssociationLogo);

            // Location <-> ServiceModel/Response
            TypeAdapterConfig<CompanyLocation, CompanyLocationServiceModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.LocationId, src => src.LocationId)
                .Map(dest => dest.LocationName, src => src.Location.City);

            TypeAdapterConfig<CompanyLocationServiceModel, CompanyLocationResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.LocationId, src => src.LocationId)
                .Map(dest => dest.LocationName, src => src.LocationName);

            // Map List<CompanyAssociation> <-> List<Guid>
            TypeAdapterConfig<List<CompanyAssociation>, List<Guid>>.NewConfig()
                .MapWith(src => src.Select(a => a.AssociationId).ToList());
            TypeAdapterConfig<List<Guid>, List<CompanyAssociation>>.NewConfig()
                .MapWith(src => src.Select(id => new CompanyAssociation { AssociationId = id }).ToList());

            //// Map List<CompanyLocation> <-> List<Guid>
            TypeAdapterConfig<List<CompanyLocation>, List<Guid>>.NewConfig()
                .MapWith(src => src.Select(l => l.LocationId).ToList());
            TypeAdapterConfig<List<Guid>, List<CompanyLocation>>.NewConfig()
                .MapWith(src => src.Select(id => new CompanyLocation { LocationId = id }).ToList());

        }
    }
}
