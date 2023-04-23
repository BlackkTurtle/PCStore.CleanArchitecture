﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PCStore.Domain.PCStoreEntities;

public partial class PartOrder
{
    public int PorderId { get; set; }

    public int Article { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }

    public virtual Product ArticleNavigation { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
