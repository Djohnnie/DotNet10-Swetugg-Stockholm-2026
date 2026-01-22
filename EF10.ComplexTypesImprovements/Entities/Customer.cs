namespace EF10.ComplexTypesImprovements.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address ShippingAddress { get; set; }
    public Address? BillingAddress { get; set; }
    public BusinessInfo BusinessInfo { get; set; }
}