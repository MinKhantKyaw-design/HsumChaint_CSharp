using HsumChaint.Infrastructure.Models;
using HsumChaint.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HsumChaint.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        #region AddUser
        public async Task<CommonResponseModel<User>> AddUser(User user)
        {
            var response = new CommonResponseModel<User>();

            try
            {
                await _context.Users.AddAsync(user);

                var saveResponse = await _context.SaveChangesAsync();

                if (saveResponse > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "add user successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "something went wrong";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Repo Layer  Exception :{ex.Message}";
            }
            return response;
        }
        #endregion

        #region GetAllUsers
        public async Task<CommonResponseModel<IEnumerable<User>>> GetAllUsersAsync()
        {
            var response = new CommonResponseModel<IEnumerable<User>>();
            try
            {
                var users = await _context.Users
                    .Where(u => u.IsDeleted == false || u.IsDeleted == null)
                    .ToListAsync();
                    
                response.IsSuccess = true;
                response.Message = "Users retrieved successfully";
                response.Data = users; // Assuming Data property exists in CommonResponseModel
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Repo Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion

        #region GetUserById
        public async Task<CommonResponseModel<User>> GetUserByIdAsync(int id)
        {
            var response = new CommonResponseModel<User>();
            try
            {
                var user = await _context.Users
                    .Where(u => (u.IsDeleted == false || u.IsDeleted == null) && u.Id == id)
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    response.IsSuccess = true;
                    response.Message = "User found";
                    response.Data = user; // Assuming Data property exists in CommonResponseModel
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Repo Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion

        #region UpdateUser
        public async Task<CommonResponseModel<User>> UpdateUserAsync(User user)
        {
            var response = new CommonResponseModel<User>();
            try
            {
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null || existingUser.IsDeleted == true)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found or is deleted";
                    return response;
                }

                // Update properties
                existingUser.Name = user.Name;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Password = user.Password; // Usually you'd hash this, assuming basic CRUD for now
                existingUser.UserType = user.UserType;
                existingUser.FcmToken = user.FcmToken;
                existingUser.UpdatedAt = DateTime.UtcNow;

                _context.Users.Update(existingUser);
                var saveResponse = await _context.SaveChangesAsync();

                if (saveResponse > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "User updated successfully";
                    response.Data = existingUser; // Assuming Data property exists
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to update user";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Repo Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion

        #region DeleteUser
        public async Task<CommonResponseModel<User>> DeleteUserAsync(int id)
        {
            var response = new CommonResponseModel<User>();
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null || user.IsDeleted == true)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found or already deleted";
                    return response;
                }

                // Soft delete
                user.IsDeleted = true;
                user.UpdatedAt = DateTime.UtcNow;
                
                _context.Users.Update(user);
                var saveResponse = await _context.SaveChangesAsync();

                if (saveResponse > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "User deleted successfully";
                    response.Data = user; // Return the deleted user instance
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to delete user";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Repo Layer Exception: {ex.Message}";
            }
            return response;
        }
        #endregion
    }
}
