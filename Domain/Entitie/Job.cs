using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Job
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Title { get; set; }
    [Required]
    public decimal MinSalary { get; set; }
    [Required]
    public decimal MaxSalary { get; set; }
}
