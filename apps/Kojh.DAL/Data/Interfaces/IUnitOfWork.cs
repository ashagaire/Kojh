namespace Kojh.DAL.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; set; }

        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
