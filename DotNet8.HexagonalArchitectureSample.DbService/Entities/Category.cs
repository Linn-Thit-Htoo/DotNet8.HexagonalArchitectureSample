using System;
using System.Collections.Generic;

namespace DotNet8.HexagonalArchitectureSample.DbService.Entities;

public partial class Category
{
    public long CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
