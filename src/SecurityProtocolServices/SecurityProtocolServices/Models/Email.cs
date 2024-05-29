using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class Email
{
    public string Email1 { get; set; } = null!;

    public virtual ICollection<Authorization> Authorizations { get; } = new List<Authorization>();

    public virtual ICollection<Visitor> Visitors { get; } = new List<Visitor>();
}
