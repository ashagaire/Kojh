using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kojh.DAL.Data.Interfaces;

namespace Kojh.DAL.Models
{
    public class Company : IEntity
    {
        [Key] public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }

        public string Name { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string HomePage { get; set; } = string.Empty;
        public string GeneralEmailAddress { get; set; } = string.Empty;
        public string GeneralPhoneNumber { get; set; } = string.Empty;
        public string MainAddress { get; set; } = string.Empty;
        public int NumberOfEmployee { get; set; }
        public string Established { get; set; } = string.Empty;
        public string BusinessId { get; set; } = string.Empty;
        public string ContactPersonEmail { get; set; } = string.Empty;
        public string ConciseDescription { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;

        public Guid? SocialMediasId { get; set; }
        [ForeignKey(nameof(SocialMediasId))]
        public virtual SocialMedia SocialMedia { get; set; } = null!;

        public virtual List<CompanyAssociation> Memberships { get; set; } = [];
        public virtual List<CompanyLocation> Locations { get; set; } = [];


        public CompanyLogo? Logo { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
    
}
