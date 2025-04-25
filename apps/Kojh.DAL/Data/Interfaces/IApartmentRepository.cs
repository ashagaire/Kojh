using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Models;

namespace Kojh.DAL.Data.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync(CancellationToken ct);
    }
}
