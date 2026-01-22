namespace EF10.ComplexTypesImprovements.Entities;

public struct BusinessInfo
{
    public required string CompanyName { get; set; }
    public required string TaxId { get; set; }
    public required string Country { get; set; }
}