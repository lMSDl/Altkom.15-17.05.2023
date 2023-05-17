using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Vehicle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? EngineId { get; set; }

    public virtual Engine? Engine { get; set; }

    public virtual Registration? Registration { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
