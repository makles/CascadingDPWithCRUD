using System.ComponentModel.DataAnnotations;

namespace CascadingDPWithCRUD.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmpName { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JoinDate { get; set; }
        public string? ContactNo { get; set; }
        public string? DeptName { get; set; }
        public string? DesinationName { get; set; }
    }
}
