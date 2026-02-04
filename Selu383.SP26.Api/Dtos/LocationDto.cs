namespace Selu383.SP26.Api.Dtos;

public sealed class LocationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int TableCount { get; set; }
}
