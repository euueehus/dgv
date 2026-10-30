using System;
using System.Collections.Generic;

namespace dgv.Models;

public partial class Employee
{
    public Guid EmpolyeeId { get; set; }

    public Guid AccountId { get; set; }

    public Guid FactoryId { get; set; }

    public int Role { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Factory Factory { get; set; } = null!;
}
