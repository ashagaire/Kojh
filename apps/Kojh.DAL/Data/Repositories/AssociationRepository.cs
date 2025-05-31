using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kojh.DAL.Data.Repositories
{
    public class AssociationRepository : IAssociationRepository
    {
        private readonly AppDbContext _dbContext;
        public AssociationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Association>> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _dbContext.Associations.Where(a => a.Id == id).ToListAsync(ct);
        }
    }
}
