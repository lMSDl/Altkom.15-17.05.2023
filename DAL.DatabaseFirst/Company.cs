using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? CoOwnerName { get; set; }

    public int? NumberOfWorkers { get; set; }

    public string? OwnerName { get; set; }

    public int Type { get; set; }

    public bool? IsDeleted { get; set; }
}
