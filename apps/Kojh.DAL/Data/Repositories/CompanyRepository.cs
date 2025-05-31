using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Helpers;
using Kojh.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kojh.DAL.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Company?> GetCompanyByIdAsync(Guid id, CancellationToken ct, bool includeArchived = false)
        {
            var company = await _dbContext.Companies
                .Include(c => c.SocialMedia)
                .Include(c => c.Memberships)
                    .ThenInclude(m => m.Association)
                        .ThenInclude(a => a.Logo)
                .Include(c => c.Locations)
                    .ThenInclude(l => l.Location)
                .Include(c => c.Logo)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
            if (company == null || (!includeArchived && company.Archived)) return null;
           
            return company;
        }

        public async Task<List<Company>> GetAllCompaniesAsync(CancellationToken ct)
        {
            return await _dbContext.Companies
                .Include(c => c.SocialMedia)
                .Include(c => c.Memberships)
                    .ThenInclude(m => m.Association)
                        .ThenInclude(a => a.Logo)
                .Include(c => c.Locations)
                    .ThenInclude(l => l.Location)
                .Include(c => c.Logo)
                .ToListAsync(ct);
        }

        public async Task<PaginatedResponse<Company>> GetPaginatedCompanies(CompanyListFilter filter, CancellationToken ct, bool includeArchived = false)
        {
            var skip = (filter.CurrentPage - 1) * filter.PageSize;
            var query = _dbContext.Set<Company>().AsQueryable();

            if (!includeArchived)
            {
                query = query.Where(x => x.Archived == false);
            }


            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.Search.ToLower().Trim()));
            }

            var count = await query.CountAsync(ct);
            var list = await query.Skip(skip).Take(filter.PageSize).ToListAsync(ct);

            return new PaginatedResponse<Company>() { TotalCount = count, Items = list };
        }
    }
}
