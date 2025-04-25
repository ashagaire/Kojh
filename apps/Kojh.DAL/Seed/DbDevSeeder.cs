
using Kojh.DAL.Models;
using Kojh.DAL.Data;
namespace Kojh.DAL.Seed
{
    public static class DbDevSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Seed Companies
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

            // Seed Associations
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

            // Seed Locations
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

            // Seed Many-to-Many Relationships (CompanyLocation, CompanyAssociation)
            var company = context.Companies.FirstOrDefault();
            var association = context.Associations.FirstOrDefault();
            var location = context.Locations.FirstOrDefault();

            if (company != null && association != null && location != null)
            {
                // Create the CompanyLocation relationship
                var companyLocation = new CompanyLocation
                {
                    CompanyId = company.Id,
                    LocationId = location.Id,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                context.CompanyLocations.Add(companyLocation);

                // Create the CompanyAssociation relationship
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
