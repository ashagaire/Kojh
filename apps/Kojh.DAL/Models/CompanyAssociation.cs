using System.ComponentModel.DataAnnotations.Schema;
using Kojh.DAL.Data.Interfaces;


namespace Kojh.DAL.Models
{
    public class CompanyAssociation : IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }
        // Foreign keys
    
        public Guid CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; } = null!;

        public Guid AssociationId { get; set; }
        [ForeignKey(nameof(AssociationId))]
        public virtual Association Association { get; set; } = null!;

      
    }
}
