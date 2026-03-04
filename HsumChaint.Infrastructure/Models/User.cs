using System;
using System.Collections.Generic;

namespace HsumChaint.Infrastructure.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public string? UserType { get; set; }

    public string? FcmToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }
}
