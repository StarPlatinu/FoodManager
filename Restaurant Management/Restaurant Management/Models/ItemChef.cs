using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class ItemChef
{
    public long Id { get; set; }

    public long ItemId { get; set; }

    public long ChefId { get; set; }

    public byte Active { get; set; }

    public virtual User Chef { get; set; } = null!;
}
