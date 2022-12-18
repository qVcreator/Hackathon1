namespace UwULearn.Data.Entities;

public class Organization
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public string Collor { get; set; }
}
