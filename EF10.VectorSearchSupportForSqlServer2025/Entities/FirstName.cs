using Microsoft.Data.SqlTypes;

namespace EF10.VectorSearchSupportForSqlServer2025.Entities;

public class FirstName
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public SqlVector<float> Embedding { get; set; }
}