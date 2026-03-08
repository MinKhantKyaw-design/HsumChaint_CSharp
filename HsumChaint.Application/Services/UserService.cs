using HsumChaint.Application.DTOs;
using HsumChaint.Application.ServiceInterfaces;
using HsumChaint.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region AddUser
        public async Task<ApplicationCommonResponseModel<UserDto>> AddUser(UserDto reqModel)
        {
            var response = new ApplicationCommonResponseModel<UserDto>();
            try
            {
                var addResponse = await _userRepository.AddUser(new Infrastructure.Models.User
                {
                    Name = reqModel.Name,
                    PhoneNumber = reqModel.PhoneNumber,
                });

                response.IsSuccess = addResponse.IsSuccess;
                response.Message = addResponse.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Application Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion
    }
}
