using System;
using System.Collections.Generic;

namespace HsumChaint.Infrastructure.Models;

public partial class Invitation
{
    public int Id { get; set; }

    public int? MonasterySpaceId { get; set; }

    public int? InvitedUserId { get; set; }

    public int? InvitedById { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
