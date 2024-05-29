
namespace GuardianPROWebServis.ModelDTO
{
    public partial class EmployeeDTO
    {
        public int Code { get; set; }
        public int? DivisionId { get; set; }
        public int? DepartmentId { get; set; }
        public string LastName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }

        public override string ToString() => $"{LastName} {Name} {Patronymic}";
    }
}
