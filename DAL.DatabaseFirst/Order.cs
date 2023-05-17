using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Order
{
    public int Id { get; set; }

    public string Customer { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
