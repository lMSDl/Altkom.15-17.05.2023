using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Engine
{
    public int Id { get; set; }

    public int Power { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
