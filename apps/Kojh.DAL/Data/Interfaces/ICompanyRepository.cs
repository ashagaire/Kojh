using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Helpers;
using Kojh.DAL.Models;

namespace Kojh.DAL.Data.Interfaces
{
    public interface ICompanyRepository 
    {
        Task<PaginatedResponse<Company>> GetPaginatedCompanies(CompanyListFilter filter, CancellationToken ct, bool includeArchived = false);
    }
}
