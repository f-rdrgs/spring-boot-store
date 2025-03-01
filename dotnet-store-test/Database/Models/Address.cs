using System;
using System.Collections.Generic;

namespace dotnet_store_test.Database.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public int StreetNumber { get; set; }

    public string Country { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public bool? IsDefault { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
