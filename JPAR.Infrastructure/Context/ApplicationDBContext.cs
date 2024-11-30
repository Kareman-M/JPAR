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
    }
}
