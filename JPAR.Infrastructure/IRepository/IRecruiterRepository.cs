namespace JPAR.Infrastructure.IRepository
{
    public interface IRecruiterRepository
    {
        Recruiter GetByUserId(string userId);
    }
}
