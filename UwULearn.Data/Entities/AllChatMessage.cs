namespace UwULearn.Data.Entities;

public class AllChatMessage
{
    public int Id { get; set; } 
    public User From { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; }
}
