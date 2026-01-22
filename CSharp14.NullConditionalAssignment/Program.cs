// The null-conditional member access operators, ?. and ?[],
// can now be used on the left hand side of an assignment or compound assignment.
// Before C# 14, you needed to null-check a variable before assigning to a property.

Customer? customer = null;

if (customer is not null)
{
    customer.Order = GetCurrentOrder();
}

customer?.Order = GetCurrentOrder();



static string GetCurrentOrder()
{
    Console.WriteLine($"{nameof(GetCurrentOrder)} called!");
    return "Order123";
}

class Customer
{
    public string Order { get; set; }
}