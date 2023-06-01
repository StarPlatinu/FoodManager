using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class Ingredient
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long? VendorId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Summary { get; set; }

    public short Type { get; set; }

    public string Sku { get; set; } = null!;

    public double Quantity { get; set; }

    public short Unit { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual User User { get; set; } = null!;

    public virtual User? Vendor { get; set; }
}
