﻿using System;
using System.Collections.Generic;

namespace PCStore.Domain.PCStoreEntities;

public partial class Types
{
    public Types()
    {
        Products = new HashSet<Product>();
    }
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
