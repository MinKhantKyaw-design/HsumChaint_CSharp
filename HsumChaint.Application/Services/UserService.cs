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

        #region GetAllUsers
        public async Task<ApplicationCommonResponseModel<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var response = new ApplicationCommonResponseModel<IEnumerable<UserDto>>();
            try
            {
                var repoResponse = await _userRepository.GetAllUsersAsync();
                
                response.IsSuccess = repoResponse.IsSuccess;
                response.Message = repoResponse.Message;

                if (response.IsSuccess == true && repoResponse.Data != null)
                {
                    response.Data = repoResponse.Data.Select(u => new UserDto
                    {
                        Id = u.Id, // Assuming UserDto has an Id field, otherwise omit or update DTO
                        Name = u.Name,
                        PhoneNumber = u.PhoneNumber,
                        UserType = u.UserType,
                        FcmToken = u.FcmToken
                    });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Application Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion

        #region GetUserById
        public async Task<ApplicationCommonResponseModel<UserDto>> GetUserByIdAsync(int id)
        {
            var response = new ApplicationCommonResponseModel<UserDto>();
            try
            {
                var repoResponse = await _userRepository.GetUserByIdAsync(id);
                
                response.IsSuccess = repoResponse.IsSuccess;
                response.Message = repoResponse.Message;

                if (response.IsSuccess == true && repoResponse.Data != null)
                {
                    response.Data = new UserDto
                    {
                        Id = repoResponse.Data.Id,
                        Name = repoResponse.Data.Name,
                        PhoneNumber = repoResponse.Data.PhoneNumber,
                        UserType = repoResponse.Data.UserType,
                        FcmToken = repoResponse.Data.FcmToken
                    };
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Application Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion

        #region UpdateUser
        public async Task<ApplicationCommonResponseModel<UserDto>> UpdateUserAsync(int id, UserDto reqModel)
        {
            var response = new ApplicationCommonResponseModel<UserDto>();
            try
            {
                var userToUpdate = new Infrastructure.Models.User
                {
                    Id = id,
                    Name = reqModel.Name,
                    PhoneNumber = reqModel.PhoneNumber,
                    UserType = reqModel.UserType,
                    FcmToken = reqModel.FcmToken,
                    Password = reqModel.Password // Mapping if available, normally would be separate change password flow
                };

                var repoResponse = await _userRepository.UpdateUserAsync(userToUpdate);

                response.IsSuccess = repoResponse.IsSuccess;
                response.Message = repoResponse.Message;

                if (response.IsSuccess == true && repoResponse.Data != null)
                {
                    response.Data = new UserDto
                    {
                        Id = repoResponse.Data.Id,
                        Name = repoResponse.Data.Name,
                        PhoneNumber = repoResponse.Data.PhoneNumber,
                        UserType = repoResponse.Data.UserType,
                        FcmToken = repoResponse.Data.FcmToken
                    };
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Application Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion

        #region DeleteUser
        public async Task<ApplicationCommonResponseModel<string>> DeleteUserAsync(int id)
        {
            var response = new ApplicationCommonResponseModel<string>();
            try
            {
                var repoResponse = await _userRepository.DeleteUserAsync(id);
                
                response.IsSuccess = repoResponse.IsSuccess;
                response.Message = repoResponse.Message;
                // Since repoResponse.Data is a User, we can just return a success string or the ID
                if (response.IsSuccess == true)
                {
                     response.Data = $"User with ID {id} was successfully deleted.";
                }
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
