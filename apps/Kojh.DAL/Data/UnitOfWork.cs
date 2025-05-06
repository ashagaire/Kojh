using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Data.Repositories;

namespace Kojh.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public ICompanyRepository Companies { get; set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Companies = new CompanyRepository(dbContext);
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
