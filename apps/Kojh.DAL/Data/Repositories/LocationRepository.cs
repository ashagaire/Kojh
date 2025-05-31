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
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;
        public LocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Location?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(a => a.Id == id, ct);
        }
    }
}
