using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kojh.DAL.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; set; }

        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
