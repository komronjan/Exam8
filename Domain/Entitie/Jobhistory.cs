using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Jobhistory
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public int JobId { get; set; }
    public Job Job { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public Department Department { get; set; }
}
