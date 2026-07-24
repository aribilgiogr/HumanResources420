using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .HasOne(c => c.Employer)
                .WithOne(u => u.Company)
                .HasForeignKey<Company>(c => c.EmployerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<JobPosting>()
                .HasOne(j => j.Company)
                .WithMany(c => c.JobPostings)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<JobApplication>()
                .HasOne(a => a.JobPosting)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<JobApplication>()
                .HasOne(a => a.Candidate)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<JobPosting>()
                .Navigation(j => j.Company)
                .AutoInclude();
        }
    }
}
