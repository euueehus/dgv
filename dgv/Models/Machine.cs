using System;
using System.Collections.Generic;

namespace dgv.Models;

public partial class Machine
{
    public Guid MachinelId { get; set; }

    public Guid FactoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime MachineCreateDateTime { get; set; }

    public int Status { get; set; }

    public virtual Factory Factory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
