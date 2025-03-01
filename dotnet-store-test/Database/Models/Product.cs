using System;
using System.Collections.Generic;
using dotnet_store_test.Database.Enums;

namespace dotnet_store_test.Database.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public double? Price { get; set; }

    public int QuantityInStock { get; set; }

    public int? IdCategory { get; set; }

    public ProductsCurrentStatus currentStatus { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();
}
