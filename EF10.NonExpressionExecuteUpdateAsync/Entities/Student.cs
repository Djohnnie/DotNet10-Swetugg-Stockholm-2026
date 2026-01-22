namespace EF10.NonExpressionExecuteUpdateAsync.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public DateOnly BirthDay { get; set; }
}