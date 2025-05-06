using System.ComponentModel.DataAnnotations;
using Kojh.DAL.Data.Interfaces;

namespace Kojh.DAL.Models
{
    public class Association : IEntity
    {
        [Key] public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Esatblished { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AssociationLogo? Logo { get; set; }

        public virtual List<CompanyAssociation> Companies { get; set; } = [];
    }
}
