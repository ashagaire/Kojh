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

        public async Task<IEnumerable<Item>> GetAllAsync() => await _context.Items.ToListAsync();

        public async Task<Item?> GetByIdAsync(int id) => await _context.Items.FindAsync(id);

        public async Task<Item> CreateAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> UpdateAsync(int id, Item item)
        {
            var existingItem = await _context.Items.FindAsync(id);
            if (existingItem == null) return null;

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Price = item.Price;

            await _context.SaveChangesAsync();
            return existingItem;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return false;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
