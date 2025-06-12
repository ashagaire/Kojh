using backend.Features.CompanyFeature.ServiceModels;

namespace backend.Features.CompanyFeature.Services
{
    public interface ICompanyServices
    {
        Task<CompanyServiceModel> GetCompanyByIdAsync(Guid id, CancellationToken ct);
        Task<List<CompanyServiceModel>> GetAllCompaniesAsync(CancellationToken ct);
        Task<PaginatedCompanyServiceModel> GetPaginatedCompaniesAsync(PaginatedCompanyServiceModel company, CancellationToken ct);
        Task<CompanyServiceModel> AddCompanyAsync(CompanyServiceModel company, CancellationToken ct);
        Task<CompanyServiceModel?> UpdateCompanyDetailsAsync(CompanyServiceModel company, CancellationToken ct);

        Task<CompanyServiceModel?> DeleteCompanyAsync(Guid id, CancellationToken ct);
    }
}
