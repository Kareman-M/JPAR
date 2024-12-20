using JPAR.Infrastructure.Models;
using JPAR.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JPAR.Infrastructure.Context
{
    public class ApplicationDBContext: IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UniversityDegree> UniversityDegrees { get; set; }
        public DbSet<OnlinePresence> OnlinePresences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = UserType.Applicant.ToString(), NormalizedName = UserType.Applicant.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = UserType.Recruiter.ToString(), NormalizedName = UserType.Recruiter.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() }
              );
        }
    }
}
