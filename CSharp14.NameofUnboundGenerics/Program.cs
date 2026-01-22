// Beginning with C# 14, the argument to nameof can be an unbound generic type.
// For example, nameof(List<>) evaluates to List.
// In earlier versions of C#, only closed generic types, such as List<int>, could be used to return the List name.

// Outputs: List
Console.WriteLine(nameof(List<>));

// Outputs: Dictionary
Console.WriteLine(nameof(Dictionary<,>));

// Outputs: Func
Console.WriteLine(nameof(Func<,,,,,,,,,,,,,,,,>));