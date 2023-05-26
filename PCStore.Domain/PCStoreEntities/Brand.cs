using System;
using System.Collections.Generic;

namespace PCStore.Domain.PCStoreEntities;

public class Brand
{
    public Brand()
    {
        Products = new HashSet<Product>();
    }
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
