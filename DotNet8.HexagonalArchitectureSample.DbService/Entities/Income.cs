using System;
using System.Collections.Generic;

namespace DotNet8.HexagonalArchitectureSample.DbService.Entities;

public partial class Income
{
    public long IncomeId { get; set; }

    public long Amount { get; set; }

    public DateTime Date { get; set; }

    public bool IsActive { get; set; }
}
