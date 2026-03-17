using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Application.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string UserType { get; set; }
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
        public int ID { get; set; }
    }
}
