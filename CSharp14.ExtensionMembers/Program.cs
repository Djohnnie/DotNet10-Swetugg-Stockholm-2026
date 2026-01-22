using System.Numerics;

// C# 14 adds new syntax to define extension members.
// The new syntax enables you to declare extension properties in addition to extension methods.
// You can also declare extension members that extend the type, rather than an instance of the type.
// In other words, these new extension members can appear as static members of the type you extend.
// These extensions can include user defined operators implemented as static extension methods.
// The following code example shows an example of the different kinds of extension members you can declare.

var list = new List<int> { 1, 2, 3, 4, 5 };
var large = list.WhereGreaterThan3(3);

if (large.IsEmpty)
{
    Console.WriteLine("No large numbers");
}
else
{
    Console.WriteLine("Found large numbers");
}

_ = List<int>.Create();

var list3 = list + large;


public static class Extensions1
{
    public static IEnumerable<int> WhereGreaterThan1(this IEnumerable<int> source, int threshold)
        => source.Where(x => x > threshold);
}

public static class Extensions2
{
    extension(IEnumerable<int> source)
    {
        public IEnumerable<int> WhereGreaterThan2(int threshold)
            => source.Where(x => x > threshold);

        public bool IsEmpty
            => !source.Any();
    }

    extension<T>(IEnumerable<T> source) where T : INumber<T>
    {
        public IEnumerable<T> WhereGreaterThan3(T threshold)
            => source.Where(x => x > threshold);

        public bool IsEmpty
            => !source.Any();

        public static IEnumerable<T> operator +(IEnumerable<T> left, IEnumerable<T> right)
            => left.Concat(right);
    }

    extension<T>(List<T>)
    {
        public static List<T> Create()
            => [];
    }
}