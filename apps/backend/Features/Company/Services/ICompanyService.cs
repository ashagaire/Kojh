using backend.Features.Company.ServiceModels;

namespace backend.Features.Company.Services
{
    public interface ICompanyServices
    {
        Task<List<CompanyServiceModel>> GetAllCompaniesAsync(CancellationToken ct);
        Task<PaginatedCompanyServiceModel> GetPaginatedCompaniesAsync(PaginatedCompanyServiceModel company, CancellationToken ct);
    }
}
