namespace EF10.JsonTypeSupportForSqlServer2025.Entities;

public class Blog
{
    public int Id { get; set; }
    public string[] Tags { get; set; }
    public required BlogDetails Details { get; set; }
}