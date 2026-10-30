using System;
using System.Collections.Generic;

namespace dgv.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public long ProductNo { get; set; }

    public Guid FactoryId { get; set; }

    public Guid MachinelId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public string Detail { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public virtual Factory Factory { get; set; } = null!;

    public virtual Machine Machinel { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
