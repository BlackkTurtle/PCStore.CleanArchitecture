﻿using System;
using System.Collections.Generic;

namespace PCStore.Domain.PCStoreEntities;

public class Order
{
    public Order()
    {
        PartOrders = new HashSet<PartOrder>();
    }
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Adress { get; set; } = null!;

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<PartOrder> PartOrders { get; } = new List<PartOrder>();

    public virtual Status Status { get; set; } = null!;
}
