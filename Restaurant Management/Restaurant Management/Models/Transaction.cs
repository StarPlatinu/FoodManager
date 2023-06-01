using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class Transaction
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long VendorId { get; set; }

    public long OrderId { get; set; }

    public string Code { get; set; } = null!;

    public short Type { get; set; }

    public short Mode { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual User Vendor { get; set; } = null!;
}
