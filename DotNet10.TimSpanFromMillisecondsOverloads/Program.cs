using System.Linq.Expressions;

// The TimeSpan.FromMilliseconds(Int64, Int64) method was introduced previously
// without adding an overload that takes a single parameter.
// Although this works since the second parameter is optional, it causes a compilation error
// when used in a LINQ expression.
// The issue arises because LINQ expressions can't handle optional parameters.
// To address this, .NET 10 introduces a new overload takes a single parameter.
// It also modifies the existing method to make the second parameter mandatory.

TimeSpan timeSpanA = TimeSpan.FromMilliseconds(milliseconds: 832, microseconds: 0);
Console.WriteLine($"timeSpanA = {timeSpanA}");

TimeSpan timeSpanB = TimeSpan.FromMilliseconds(milliseconds: 832);
Console.WriteLine($"timeSpanB = {timeSpanA}");

Expression<Action> a = () => TimeSpan.FromMilliseconds(1000);