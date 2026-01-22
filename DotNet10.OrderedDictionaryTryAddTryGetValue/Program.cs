// OrderedDictionary<TKey,TValue> provides TryAdd and TryGetValue for addition and retrieval
// like any other IDictionary<TKey, TValue> implementation.
// However, there are scenarios where you might want to perform more operations,
// so new overloads are added that return an index to the entry:
// - TryAdd(TKey, TValue, Int32)
// - TryGetValue(TKey, TValue, Int32)
// This index can then be used with GetAt and SetAt for fast access to the entry.
// An example usage of the new TryAdd overload is to add or update a key-value pair in the ordered dictionary.

var dict = new OrderedDictionary<string, WindDirection>
{
    ["N"] = WindDirection.North,
    ["E"] = WindDirection.East,
    ["S"] = WindDirection.South
};

dict.TryAdd("W", WindDirection.West, out int index);
Console.WriteLine($"\"W\" added with index '{index}'");

dict.TryGetValue("N", out WindDirection directionN, out int indexN);
Console.WriteLine($"\"N\" has index '{indexN}'");
dict.TryGetValue("E", out WindDirection directionE, out int indexE);
Console.WriteLine($"\"E\" has index '{indexE}'");
dict.TryGetValue("S", out WindDirection directionS, out int indexS);
Console.WriteLine($"\"S\" has index '{indexS}'");


enum WindDirection
{
    North,
    East,
    South,
    West
}