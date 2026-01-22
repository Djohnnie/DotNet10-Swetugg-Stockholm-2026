namespace EF10.ComplexTypesImprovements.Entities;

public struct Address
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string ZipCode { get; set; }
}