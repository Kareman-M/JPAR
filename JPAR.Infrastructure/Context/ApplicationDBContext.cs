using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JPAR.Infrastructure.Context
{
    public class ApplicationDBContext: IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        DbSet<Applicant> Applicants { get; set; }
        DbSet<Certification> Certifications { get; set; }
        DbSet<Recruiter> Recruiters { get; set; }
    }
}
