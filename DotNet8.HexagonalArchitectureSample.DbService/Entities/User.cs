using System;
using System.Collections.Generic;

namespace DotNet8.HexagonalArchitectureSample.DbService.Entities;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string UserRole { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsActive { get; set; }
}