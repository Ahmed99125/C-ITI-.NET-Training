using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class EmpInfo
{
    public int Ssn { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Dname { get; set; }

    public int? Salary { get; set; }
}
