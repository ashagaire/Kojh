namespace Kojh.DAL.Data.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? ArchivedAt { get; set; }
        public bool Archived { get; set; }
    }
}
