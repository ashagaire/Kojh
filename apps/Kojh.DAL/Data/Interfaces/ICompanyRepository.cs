using Kojh.DAL.Helpers;
using Kojh.DAL.Models;

namespace Kojh.DAL.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company?> GetCompanyByIdAsync(Guid id, CancellationToken ct, bool includeArchived = false);
        Task<List<Company>> GetAllCompaniesAsync(CancellationToken ct);
        Task<PaginatedResponse<Company>> GetPaginatedCompanies(CompanyListFilter filter, CancellationToken ct, bool includeArchived = false);
        Task<Company> AddCompanyAsync(Company company, CancellationToken ct);
        Task<Company?> UpdateCompanyAsync(Company company, CancellationToken ct);
    }
}
