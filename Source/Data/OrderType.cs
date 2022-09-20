using Source.TypeSafeEnums;

namespace Source.Data;

#pragma warning disable CS8618

public class OrderType
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string? Description { get; set; }
}