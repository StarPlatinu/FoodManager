using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class Booking
{
    public long Id { get; set; }

    public long TableId { get; set; }

    public long? UserId { get; set; }

    public string Token { get; set; } = null!;

    public short Status { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Line1 { get; set; }

    public string? Line2 { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Country { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<BookingItem> BookingItems { get; set; } = new List<BookingItem>();

    public virtual TableTop Table { get; set; } = null!;

    public virtual User? User { get; set; }
}
