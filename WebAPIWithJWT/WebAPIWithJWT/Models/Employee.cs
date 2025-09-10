using System.ComponentModel.DataAnnotations;

namespace WebAPIWithJWT.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpDepartment { get; set; }
        public double EmpSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
