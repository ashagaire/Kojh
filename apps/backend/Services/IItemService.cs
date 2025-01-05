using Deraa.DAL.Models;

namespace backend.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Apartment>> GetAllAsync();
        Task<Apartment?> GetByIdAsync(int id);
        Task<Apartment> CreateAsync(Apartment item);
        Task<Apartment?> UpdateAsync(int id, Apartment item);
        Task<bool> DeleteAsync(int id);
    }
}
