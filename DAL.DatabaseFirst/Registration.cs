using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Registration
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public int? VehicleId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
