using System;
using System.Collections.Generic;

namespace Employee_Registration.Entity;

public partial class EmployeeMst
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int Age { get; set; }

    public string MobileNum { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public virtual CountryMst? Country { get; set; }

    public virtual StateMst? State { get; set; }
}
