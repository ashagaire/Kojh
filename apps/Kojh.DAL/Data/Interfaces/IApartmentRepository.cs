using Kojh.DAL.Models;

namespace Kojh.DAL.Data.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync(CancellationToken ct);
    }
}
