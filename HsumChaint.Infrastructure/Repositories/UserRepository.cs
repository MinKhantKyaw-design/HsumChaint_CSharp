using HsumChaint.Infrastructure.Models;
using HsumChaint.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
