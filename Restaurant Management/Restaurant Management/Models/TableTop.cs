using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class TableTop
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public short Status { get; set; }

    public short Capacity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
