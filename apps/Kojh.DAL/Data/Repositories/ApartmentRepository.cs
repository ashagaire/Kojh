using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kojh.DAL.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Items.ToListAsync(ct);
        }
    }
}
