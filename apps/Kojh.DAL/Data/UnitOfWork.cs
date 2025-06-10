using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Data.Repositories;

namespace Kojh.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public ICompanyRepository Companies { get; set; }
        public IAssociationRepository Associations { get; set; }
        public ILocationRepository Locations { get; set; }
        public ICompanyAssociationRepository CompanyAssociations { get; set; }
        public ICompanyLocationRepository CompanyLocations { get; set; }


        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Companies = new CompanyRepository(dbContext);
            Associations = new AssociationRepository(dbContext);
            Locations = new LocationRepository(dbContext);
            CompanyAssociations = new CompanyAssociationRepository(dbContext);
            CompanyLocations = new CompanyLocationRepository(dbContext);
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
