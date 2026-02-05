using System.ComponentModel.DataAnnotations;

namespace Selu383.SP26.Api.Dtos;

public class LocationDto
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int TableCount { get; set; }
}