using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class Recipe
{
    public long Id { get; set; }

    public long ItemId { get; set; }

    public long IngredientId { get; set; }

    public double Quantity { get; set; }

    public short Unit { get; set; }

    public string? Instructions { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;
}
