using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Region
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(25)]
    public string RegionName { get; set; }
}
