using Kojh.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Kojh.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CompanyAssociation> CompanyAssociations { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }
        public DbSet<CompanyLogo> CompanyLogos { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<AssociationLogo> AssociationLogos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyLocation>()
                .HasIndex(cl => new { cl.CompanyId, cl.LocationId });

            modelBuilder.Entity<CompanyLocation>()
                .HasOne(cl => cl.Company)
                .WithMany(c => c.Locations)
                .HasForeignKey(cl => cl.CompanyId);

            modelBuilder.Entity<CompanyLocation>()
                .HasOne(cl => cl.Location)
                .WithMany(l => l.Companies)
                .HasForeignKey(cl => cl.LocationId);

            modelBuilder.Entity<CompanyAssociation>()
                .HasIndex(ca => new { ca.CompanyId, ca.AssociationId });

            modelBuilder.Entity<CompanyAssociation>()
                .HasOne(ca => ca.Company)
                .WithMany(c => c.Memberships)
                .HasForeignKey(ca => ca.CompanyId);

            modelBuilder.Entity<CompanyAssociation>()
                .HasOne(ca => ca.Association)
                .WithMany(a => a.Companies)
                .HasForeignKey(ca => ca.AssociationId);
        }
    }
}
