using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Data.Interfaces;

namespace Kojh.DAL.Models
{
    public class CompanyLocation : IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }
    
        public Guid CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; } = null!;

        public Guid LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; } = null!;
    }
}
