
using Kojh.DAL.Data;
using Kojh.DAL.Models;
namespace Kojh.DAL.Seed
{
    public static class DbDevSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Companies.Any())
            {
                var newCompany = new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Company",
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                context.Companies.Add(newCompany);
                context.SaveChanges();
            }

            if (!context.Associations.Any())
            {
                var newAssociation = new Association
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Association",
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                context.Associations.Add(newAssociation);
                context.SaveChanges();
            }

            if (!context.Locations.Any())
            {
                var newLocation = new Location
                {
                    Id = Guid.NewGuid(),
                    City = "Sample Location",
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                context.Locations.Add(newLocation);
                context.SaveChanges();
            }

            var company = context.Companies.FirstOrDefault();
            var association = context.Associations.FirstOrDefault();
            var location = context.Locations.FirstOrDefault();

            if (company != null && association != null && location != null)
            {
                var companyLocation = new CompanyLocation
                {
                    CompanyId = company.Id,
                    LocationId = location.Id,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                context.CompanyLocations.Add(companyLocation);

                var companyAssociation = new CompanyAssociation
                {
                    CompanyId = company.Id,
                    AssociationId = association.Id,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                context.CompanyAssociations.Add(companyAssociation);
                context.SaveChanges();
            }
        }
    }
}
