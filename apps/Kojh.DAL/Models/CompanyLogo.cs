using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Data.Interfaces;

namespace Kojh.DAL.Models
{
    public class CompanyLogo : IEntity
    {
        [Key] public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }

        public string Image { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }
    }
}
