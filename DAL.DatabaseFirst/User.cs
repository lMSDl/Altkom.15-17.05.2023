using System;
using System.Collections.Generic;

namespace DAL.DatabaseFirst;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Type { get; set; } = null!;
}
