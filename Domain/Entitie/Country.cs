using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Country
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string CountryName { get; set; }
    [Required]
    public int RegionId { get; set; }
    public Region Region { get; set; }
}
