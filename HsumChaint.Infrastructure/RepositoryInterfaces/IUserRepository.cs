using HsumChaint.Infrastructure.Models;

namespace HsumChaint.Infrastructure.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<CommonResponseModel<User>> AddUser(User user);
        Task<CommonResponseModel<IEnumerable<User>>> GetAllUsersAsync();
        Task<CommonResponseModel<User>> GetUserByIdAsync(int id);
        Task<CommonResponseModel<User>> UpdateUserAsync(User user);
        Task<CommonResponseModel<User>> DeleteUserAsync(int id);
    }
}