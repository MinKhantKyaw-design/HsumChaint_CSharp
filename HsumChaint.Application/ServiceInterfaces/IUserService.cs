using HsumChaint.Application.DTOs;

namespace HsumChaint.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<ApplicationCommonResponseModel<UserDto>> AddUser(UserDto reqModel);
    }
}