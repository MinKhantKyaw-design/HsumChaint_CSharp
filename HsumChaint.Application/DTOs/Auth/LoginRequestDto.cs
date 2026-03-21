using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Application.DTOs.Auth
{
    public class LoginRequestDto
    {
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
