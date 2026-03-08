using System;
using System.Collections.Generic;

namespace HsumChaint.Infrastructure.Models;

public partial class DonorList
{
    public int Id { get; set; }

    public int? MonasterySpaceId { get; set; }

    public int? DonorId { get; set; }

    public string? DonorName { get; set; }

    public string? DonationType { get; set; }

    public string? Status { get; set; }

    public int? ReviewerId { get; set; }
}
