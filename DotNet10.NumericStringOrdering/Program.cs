using System.Globalization;

// Numerical string comparison is a highly requested feature for comparing strings numerically instead of lexicographically.
// For example, 2 is less than 10, so "2" should appear before "10" when ordered numerically. Similarly, "2" and "02" are equal numerically.
// With the new NumericOrdering option, it's now possible to do these types of comparisons.

var versions = new List<LanguageVersion>
{
    new LanguageVersion { CSharpVersion = "8.0" },
    new LanguageVersion { CSharpVersion = "9.0" },
    new LanguageVersion { CSharpVersion = "10.0" },
    new LanguageVersion { CSharpVersion = "11.0" },
    new LanguageVersion { CSharpVersion = "12.0" },
    new LanguageVersion { CSharpVersion = "13.0" },
    new LanguageVersion { CSharpVersion = "14.0" }
};

foreach (var version in versions.OrderBy(x => x.CSharpVersion))
{
    Console.WriteLine(version.CSharpVersion);
}

Console.WriteLine("-");

var numericStringComparer = StringComparer.Create(CultureInfo.CurrentCulture, CompareOptions.NumericOrdering);
foreach (var version in versions.OrderBy(x => x.CSharpVersion, numericStringComparer))
{
    Console.WriteLine(version.CSharpVersion);
}

class LanguageVersion
{
    public string CSharpVersion { get; set; }
}