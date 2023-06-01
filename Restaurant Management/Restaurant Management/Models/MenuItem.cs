using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class MenuItem
{
    public long Id { get; set; }

    public long MenuId { get; set; }

    public long ItemId { get; set; }

    public byte Active { get; set; }

    public virtual Item Item { get; set; } = null!;
}
