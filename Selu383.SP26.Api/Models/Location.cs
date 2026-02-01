using System.ComponentModel.DataAnnotations;
// Provides validation attributes used by EF Core

namespace Selu383.SP26.Api.Models;

public sealed class Location
{
    public int Id { get; set; }
    // Primary key (EF Core automatically treats "Id" as the PK)

    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;
    // Required name, max length 120 (matches assignment + tests)

    [Required]
    public string Address { get; set; } = string.Empty;
    // Required address

    [Range(1, int.MaxValue)]
    public int TableCount { get; set; }
    // Must be at least 1
}
