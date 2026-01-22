namespace EF10.LeftJoinAndRightJoin.Entities;

public class Address
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string City { get; set; }
}