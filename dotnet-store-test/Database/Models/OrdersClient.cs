using System;
using System.Collections.Generic;

namespace dotnet_store_test.Database.Models;

public class OrdersClient
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();
}
