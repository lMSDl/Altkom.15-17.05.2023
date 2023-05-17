using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class RemoteAddress
{
    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
