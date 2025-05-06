using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
