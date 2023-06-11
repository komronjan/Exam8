using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class JobGrade
{
    [Key]
    public string GradeLelel { get; set; }
    [Required]
    public decimal LowestSal { get; set; }
    [Required]
    public decimal HighesttSal { get; set; }

}
