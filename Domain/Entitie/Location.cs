using System.ComponentModel.DataAnnotations;

namespace Domain.Entitie;

public class Location
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string StreetAddress { get; set; }
    [Required, MaxLength(40)]
    public string PostalCode { get; set; }
    [Required, MaxLength(30)]
    public string City { get; set; }
    [Required,MaxLength(25)]
    public string StateProvince { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
}
