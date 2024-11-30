using System;
using System.Collections.Generic;

namespace Employee_Registration.Entity;

public partial class CountryMst
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<EmployeeMst> EmployeeMsts { get; set; } = new List<EmployeeMst>();

    public virtual ICollection<StateMst> StateMsts { get; set; } = new List<StateMst>();
}
