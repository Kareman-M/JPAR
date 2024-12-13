using JPAR.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

    }
}
