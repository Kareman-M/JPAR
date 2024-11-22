namespace JPAR.Infrastructure.IRepository
{
    public interface IApplicantRepository
    {
        Applicant GetById(int id);
        bool Add(Applicant applicant);
        bool Update(Applicant applicant);
        bool Delete(int id);
    }
}
