using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Pesel { get; set; }

    public int Age { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid Guid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string FullName { get; set; } = null!;

    public virtual Educator? Educator { get; set; }

    public virtual Student? Student { get; set; }
}
