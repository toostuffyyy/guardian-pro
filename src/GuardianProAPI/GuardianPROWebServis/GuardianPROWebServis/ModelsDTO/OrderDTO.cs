using System;
using System.Collections.Generic;
using System.Linq;

namespace GuardianPROWebServis.ModelDTO
{
    public partial class OrderDTO
    {
        public int Id { get; set; }
        public int CodeEmployee { get; set; }
        public int TypeOrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GoalVisit { get; set; } = null!;
        public string? NameGroup { get; set; }
        public string? ReasonForRefusal { get; set; }
        public string? Purpose { get; set; }
        public virtual List<VisitorDTO> Visitors { get; set; }
    }
}
