namespace JPAR.Infrastructure.IRepository
{
    public interface IApplicantRepository
    {
        Applicant GetByUserId(string userId);
        bool Add(string userId);
        Applicant Update(Applicant applicant);
        bool Delete(int id);
    }
}
