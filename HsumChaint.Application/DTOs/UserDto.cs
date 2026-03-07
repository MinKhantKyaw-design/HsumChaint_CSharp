using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserType { get; set; }
        public string? FcmToken { get; set; }
        public string? Password { get; set; }
    }
}
