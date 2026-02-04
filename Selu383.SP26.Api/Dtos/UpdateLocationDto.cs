using System.ComponentModel.DataAnnotations;
// Provides validation attributes

namespace Selu383.SP26.Api.Dtos;

public sealed class UpdateLocationDto
{
    [Required]
    // Name must be provided

    [MaxLength(120)]
    // Name cannot exceed 120 characters

    public string Name { get; set; } = string.Empty;

    [Required]
    // Address must be provided

    public string Address { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    // TableCount must be at least 1

    public int TableCount { get; set; }
}
