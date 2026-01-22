Console.WriteLine("Hello World!");

// You can now declare instance constructors and events as partial members.
// Partial constructors and partial events must include exactly one defining declaration and one implementing declaration.
// Only the implementing declaration of a partial constructor can include a constructor initializer: this() or base().
// Only one partial type declaration can include the primary constructor syntax.
// The implementing declaration of a partial event must include add and remove accessors.
// The defining declaration declares a field-like event.

// Partial constructors

partial class MyPartialClass1
{
    public partial MyPartialClass1();
}

partial class MyPartialClass1
{
    // Partial member may not have multiple defining declarations.
    // public partial MyPartialClass1();
}

partial class MyPartialClass1
{
    public partial MyPartialClass1()
    {
        Console.WriteLine("Constructor...");
    }
}

partial class MyPartialClass1
{
    // Partial member may not have multiple implementing declarations.
    // public partial MyPartialClass1()
    // {
    //     Console.WriteLine("Constructor...");
    // }
}

// Partial events

partial class MyPartialClass2
{
    public partial event Action<int, string> MyEvent;
}

partial class MyPartialClass2
{
    private event Action<int, string> _myEvent;

    public partial event Action<int, string> MyEvent
    {
        add { _myEvent += value; }
        remove { _myEvent -= value; }
    }
}