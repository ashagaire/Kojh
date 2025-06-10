namespace Kojh.DAL.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; set; }
        IAssociationRepository Associations { get; set; }
        ILocationRepository Locations { get; set; }
        ICompanyAssociationRepository CompanyAssociations { get; set; }
        ICompanyLocationRepository CompanyLocations { get; set; }

        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
