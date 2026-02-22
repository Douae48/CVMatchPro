using linkedin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace linkedin.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Offre> Offres { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Candidature> candidatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key
            modelBuilder.Entity<Candidature>()
                .HasKey(oc => new { oc.OffreId, oc.CVId });

            // Configure relationships
            modelBuilder.Entity<Candidature>()
                .HasOne(oc => oc.Offre)
                .WithMany(o => o.candidatures)
                .HasForeignKey(oc => oc.OffreId);

            modelBuilder.Entity<Candidature>()
                .HasOne(oc => oc.CV)
                .WithMany(c => c.candidatures)
                .HasForeignKey(oc => oc.CVId);
        }
    }
}
