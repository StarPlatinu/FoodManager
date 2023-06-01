using System;
using System.Collections.Generic;

namespace Restaurant_Management.Models;

public partial class User
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public byte Admin { get; set; }

    public byte Vendor { get; set; }

    public byte Chef { get; set; }

    public byte Agent { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Intro { get; set; }

    public string? Profile { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Ingredient> IngredientUsers { get; set; } = new List<Ingredient>();

    public virtual ICollection<Ingredient> IngredientVendors { get; set; } = new List<Ingredient>();

    public virtual ICollection<ItemChef> ItemChefs { get; set; } = new List<ItemChef>();

    public virtual ICollection<Item> ItemUsers { get; set; } = new List<Item>();

    public virtual ICollection<Item> ItemVendors { get; set; } = new List<Item>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Order> OrderUsers { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderVendors { get; set; } = new List<Order>();

    public virtual ICollection<Transaction> TransactionUsers { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionVendors { get; set; } = new List<Transaction>();
}
