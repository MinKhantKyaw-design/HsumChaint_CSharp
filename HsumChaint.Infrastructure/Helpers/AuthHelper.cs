using HsumChaint.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Infrastructure.Helpers
{
    public class AuthHelper
    {
        private readonly AppDbContext _dbContext;

        public AuthHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region HashAndReturnPassword
        public async Task<string> HashAndReturnPassword(string password)
        {
            var hashedPassword = new PasswordHasher<User>().HashPassword(new User(), password);

            return hashedPassword;
        }
        #endregion




    }
}
