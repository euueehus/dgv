using System;
using System.Collections.Generic;

namespace dgv.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid BuyerId { get; set; }

    public Guid ProductId { get; set; }

    public decimal CostMoney { get; set; }

    public decimal ServiceCharge { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreateDateTime { get; set; }

    public int Status { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Account Buyer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
