using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Models;

namespace Kojh.DAL.Data.Repositories
{

    public class CompanyLocationRepository : ICompanyLocationRepository
    {
        private readonly AppDbContext _dbContext;
        public CompanyLocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CompanyLocation>> AddCompanyLocationAsync(List<CompanyLocation> companyLocations, CancellationToken ct)
        {
            List<CompanyLocation> addedEntities = [];
            foreach (var entity in companyLocations)
            {
                entity.Id = Guid.NewGuid();
                addedEntities.Add(entity);
            }
            await _dbContext.CompanyLocations.AddRangeAsync(addedEntities, ct);
            await _dbContext.SaveChangesAsync(ct);
            return addedEntities;
        }
    }
}
