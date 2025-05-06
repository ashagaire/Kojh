using System.ComponentModel.DataAnnotations;
using Kojh.DAL.Data.Interfaces;

namespace Kojh.DAL.Models
{
    public class SocialMedia : IEntity
    {
        [Key] public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }

        public string Facebook { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Youtube { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }
    }
}
