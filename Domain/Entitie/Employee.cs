using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required, MaxLength(50)]
    public string EmailAddress { get; set; }
    [Required, MaxLength(20)]
    public string PhoneNumber { get; set; }
    public DateTime HairDate { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
    public decimal Salary { get; set; }
    public int Commission_pct { get; set; }
    public int ManagerId { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}
