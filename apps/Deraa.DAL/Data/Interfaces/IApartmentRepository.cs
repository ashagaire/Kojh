using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deraa.DAL.Models;

namespace Deraa.DAL.Data.Interfaces
{
    public interface IApartmentRepository
    {
        Task<List<Apartment>> GetAllAsync(CancellationToken ct);
    }
}
