using System;
using System.Collections.Generic;

namespace dotnet_store_test.Database.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public int? SubcategoryId { get; set; }

    public virtual ICollection<Category> InverseSubcategory { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Category? Subcategory { get; set; }
}
