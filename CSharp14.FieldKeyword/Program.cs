// The token field enables you to write a property accessor body without declaring an explicit backing field.
// The token field is replaced with a compiler synthesized backing field.

Console.WriteLine(new Person
{
    NameInCaps = "Johnny Hooyberghs"
});

Console.WriteLine(new NewsItem
{
    Title = "C# 14.0 is out!"
});

Console.ReadKey();


public class Person
{
    public string NameInCaps
    {
        get => field;
        set => field = value.ToUpper();
    }

    public override string ToString()
    {
        return NameInCaps;
    }
}

public class NewsItem
{
    private string field = "sjdgf";

    public string Title
    {
        get => @field;
        set => @field = value;
    }

    public string Warning
    {
        get => field;
        set => field = value;
    }

    public override string ToString()
    {
        return field;
    }
}