namespace UwULearn.Data.Entities;

public class Lesson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Text { get; set; }
    public string Video { get; set; } // url 
    public bool IsDeleted { get; set; }
}