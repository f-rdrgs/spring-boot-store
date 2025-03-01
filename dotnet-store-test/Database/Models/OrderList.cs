using System;
using System.Collections.Generic;

namespace dotnet_store_test.Database.Models;

public partial class OrderList
{
    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int? Quantity { get; set; }

    public double? PriceAtOrder { get; set; }

    public virtual OrdersClient IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
