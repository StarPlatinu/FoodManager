using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class Item
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long? VendorId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Summary { get; set; }

    public short Type { get; set; }

    public byte Cooking { get; set; }

    public string Sku { get; set; } = null!;

    public double Price { get; set; }

    public double Quantity { get; set; }

    public short Unit { get; set; }

    public string? Recipe { get; set; }

    public string? Instructions { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;

    public virtual User? Vendor { get; set; }
}
