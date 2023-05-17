using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class SuperStudent
{
    public int Id { get; set; }

    public string SuperAbility { get; set; } = null!;

    public virtual Student IdNavigation { get; set; } = null!;
}
