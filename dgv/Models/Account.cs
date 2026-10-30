using System;
using System.Collections.Generic;

namespace dgv.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte Gender { get; set; }

    public byte AccountType { get; set; }

    public string Email { get; set; } = null!;

    public byte AccountStatus { get; set; }

    public DateTimeOffset? LastPasswordChanged { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
