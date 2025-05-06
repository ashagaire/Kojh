using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kojh.DAL.Helpers
{
    public class PaginatedResponse<TEntity>
    {
        public int TotalCount { get; set; }
        public List<TEntity> Items { get; set; } = [];
    }
}
