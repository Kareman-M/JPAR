using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;

namespace JPAR.Service.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepository;
        private readonly IRecruiterRepository _recruiterRepository;
       
        public JobPostService(IJobPostRepository jobPostRepository, IRecruiterRepository recruiterRepository)
        {
            this._jobPostRepository = jobPostRepository;
            _recruiterRepository = recruiterRepository;
        }

        public bool Add(AddJobPostDTO addJobPostDTO, string userId)
        {
            var recruiterId = _recruiterRepository.GetByUserId(userId).Id;
            var job = new JobPost
            {
                Title = addJobPostDTO.Title,
                JobDescription = addJobPostDTO.JobDescription,
                CareerLevel = addJobPostDTO.CareerLevel,
                Categories = addJobPostDTO.Categories,
                Country = addJobPostDTO.Country,
                HideSalary = addJobPostDTO.HideSalary,
                JobTypes = addJobPostDTO.JobTypes,
                NumberOfVecancy = addJobPostDTO.NumberOfVecancy,
                WorkPlace = addJobPostDTO.WorkPlace,
                AdditinalSalaryDetails = addJobPostDTO.AdditinalSalaryDetails,
                MinSalaryRange = addJobPostDTO.MinSalaryRange,
                MaxSalaryRange = addJobPostDTO.MaxSalaryRange,
                MinYearsOfExperince = addJobPostDTO.MinYearsOfExperince,
                MaxYearsOfExperince = addJobPostDTO.MaxYearsOfExperince,
                Status = Infrastructure.Enums.JobPostStatus.Open,
                RecruiterId = recruiterId,
            };
            return _jobPostRepository.Add(job);
        }

        public bool ChangeStatus(int jobPostId, JobPostStatus jobPostStatus)
            =>  _jobPostRepository.ChangeStatus(jobPostId, jobPostStatus);

        public List<JobPostDTO> GetByUserId(string userId)
        {
            var data = _jobPostRepository.GetByUserId(userId);
            return data.Select(x => new JobPostDTO
            {
                Id = x.Id,
                Title = x.Title,
                JobTypes = x.JobTypes.Select(j=> j.ToString()).ToList(),
                Status = x.Status.ToString(),
                MaxSalaryRange = x.MaxSalaryRange,
                MaxYearsOfExperince= x.MaxYearsOfExperince,
                MinSalaryRange = x.MinSalaryRange,
                MinYearsOfExperince = x.MinYearsOfExperince,
                NumberOfVecancy = x.NumberOfVecancy,
                RecruiterId = x.RecruiterId,
                WorkPlace = x.WorkPlace.ToString(),
                AdditinalSalaryDetails = x.AdditinalSalaryDetails,
                JobDescription = x.JobDescription,
                CareerLevel = x.CareerLevel.ToString(),
                Categories = x.Categories,
                Country = x.Country,
                HideSalary = x.HideSalary,
            }).ToList();
        }
    }
}
