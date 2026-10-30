using System;
using System.Collections.Generic;

namespace dgv.Models;

public partial class Factory
{
    public Guid FactoryId { get; set; }

    public string FactoryCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
