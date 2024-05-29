using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class Document
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string Path { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
