namespace Kojh.DAL.Helpers
{
    public class PaginatedResponse<TEntity>
    {
        public int TotalCount { get; set; }
        public List<TEntity> Items { get; set; } = [];
    }
}
