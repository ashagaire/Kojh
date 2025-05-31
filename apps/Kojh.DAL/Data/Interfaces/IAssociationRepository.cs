using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kojh.DAL.Data.Interfaces
{
    public interface IAssociationRepository
    {
        Task<List<Association>> GetByIdAsync(Guid id, CancellationToken ct);
        
    }
}
