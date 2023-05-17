using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float Price { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int OrdersId { get; set; }

    public virtual Order Orders { get; set; } = null!;
}
