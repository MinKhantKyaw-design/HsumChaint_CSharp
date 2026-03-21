using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Application.DTOs.Auth
{
    public class RefreshTokenRequestDto
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
