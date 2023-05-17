using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Driver
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
