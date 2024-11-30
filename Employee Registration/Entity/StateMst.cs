using System;
using System.Collections.Generic;

namespace Employee_Registration.Entity;

public partial class StateMst
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual CountryMst? Country { get; set; }

    public virtual ICollection<EmployeeMst> EmployeeMsts { get; set; } = new List<EmployeeMst>();
}
