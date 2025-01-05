using Deraa.DAL.Data;
using Deraa.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apartment>> GetAllAsync() => await _context.Apartments.ToListAsync();

        public async Task<Apartment?> GetByIdAsync(int id) => await _context.Apartments.FindAsync(id);

        public async Task<Apartment> CreateAsync(Apartment item)
        {
            _context.Apartments.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Apartment?> UpdateAsync(int id, Apartment item)
        {
            var existingItem = await _context.Apartments.FindAsync(id);
            if (existingItem == null) return null;

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Price = item.Price;

            await _context.SaveChangesAsync();
            return existingItem;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Apartments.FindAsync(id);
            if (item == null) return false;

            _context.Apartments.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
