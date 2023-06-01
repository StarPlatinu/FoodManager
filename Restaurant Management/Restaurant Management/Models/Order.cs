using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class Order
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? VendorId { get; set; }

    public string Token { get; set; } = null!;

    public short Status { get; set; }

    public double SubTotal { get; set; }

    public double ItemDiscount { get; set; }

    public double Tax { get; set; }

    public double Shipping { get; set; }

    public double Total { get; set; }

    public string? Promo { get; set; }

    public double Discount { get; set; }

    public double GrandTotal { get; set; }

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

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }

    public virtual User? Vendor { get; set; }
}
