using Kojh.DAL.Helpers;
using Kojh.DAL.Models;

namespace Kojh.DAL.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompaniesAsync(CancellationToken ct);
        Task<PaginatedResponse<Company>> GetPaginatedCompanies(CompanyListFilter filter, CancellationToken ct, bool includeArchived = false);
    }
}
