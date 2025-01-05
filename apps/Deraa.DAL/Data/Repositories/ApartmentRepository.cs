using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deraa.DAL.Data.Interfaces;
using Deraa.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Deraa.DAL.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext _context;

        public ApartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apartment>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Apartments.ToListAsync(ct);
        }
    }
}
