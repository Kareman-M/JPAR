using JPAR.Service.DTOs;

namespace JPAR.Service.IServices
{
    public interface IUserService
    {
        public bool Register(UserRegistrationDTO user);
    }
}
