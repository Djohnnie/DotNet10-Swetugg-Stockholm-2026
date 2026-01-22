// Allow user types to customize behavior of compound assignment operators
// in a way that the target of the assignment is modified in-place.

var range = new TimeRange(TimeSpan.FromHours(1), TimeSpan.FromHours(2));
Console.WriteLine(range);

range += TimeSpan.FromMinutes(30);
Console.WriteLine(range);

range++;
Console.WriteLine(range);



class TimeRange
{
    public TimeSpan Begin { get; private set; }
    public TimeSpan End { get; private set; }

    public TimeRange(TimeSpan begin, TimeSpan end)
    {
        Begin = begin;
        End = end;
    }

    public void operator +=(TimeSpan offset)
    {
        Begin += offset;
        End += offset;
    }

    public void operator ++()
    {
        Begin += TimeSpan.FromSeconds(1);
        End += TimeSpan.FromSeconds(1);
    }

    public override string ToString()
    {
        return $"Begin: {Begin}, End: {End}";
    }
}