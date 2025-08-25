using System;
using System.Collections.Generic;

namespace SampleDotnetCoreApp.Data;

public partial class DeptTable
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
