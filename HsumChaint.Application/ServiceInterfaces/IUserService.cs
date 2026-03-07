using HsumChaint.Application.DTOs;

namespace HsumChaint.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<ApplicationCommonResponseModel<UserDto>> AddUser(UserDto reqModel);
        Task<ApplicationCommonResponseModel<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<ApplicationCommonResponseModel<UserDto>> GetUserByIdAsync(int id);
        Task<ApplicationCommonResponseModel<UserDto>> UpdateUserAsync(int id, UserDto reqModel);
        Task<ApplicationCommonResponseModel<string>> DeleteUserAsync(int id);
    }
}