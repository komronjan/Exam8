using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Department
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string DepartmentName { get; set; }
    [Required]
    public int LocationId { get; set; }
    public Location Location { get; set; }

}
