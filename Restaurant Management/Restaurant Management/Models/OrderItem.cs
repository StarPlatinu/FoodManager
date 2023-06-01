using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class OrderItem
{
    public long Id { get; set; }

    public long OrderId { get; set; }

    public long ItemId { get; set; }

    public string Sku { get; set; } = null!;

    public double Price { get; set; }

    public double Discount { get; set; }

    public double Quantity { get; set; }

    public short Unit { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
