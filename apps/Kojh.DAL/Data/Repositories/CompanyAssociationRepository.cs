using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Kojh.DAL.Data.Repositories
{
    public class CompanyAssociationRepository : ICompanyAssociationRepository
    {
        private readonly AppDbContext _dbContext;
        public CompanyAssociationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CompanyAssociation>> AddCompanyAssociationAsync(List<CompanyAssociation> companyAssociation, CancellationToken ct)
        {
            List<CompanyAssociation> addedEntities = [];
            foreach (var entity in companyAssociation)
            {
                entity.Id = Guid.NewGuid();
                addedEntities.Add(entity);
                

            }
            await _dbContext.CompanyAssociations.AddRangeAsync(addedEntities, ct);
            await _dbContext.SaveChangesAsync(ct);

            return addedEntities;
        }
        
    }
}
