using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class StandaloneAddress
{
    public int Id { get; set; }

    public float Longitude { get; set; }

    public float Latitude { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
