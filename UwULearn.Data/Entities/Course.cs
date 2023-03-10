namespace UwULearn.Data.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set;  }
    public string Description { get; set; }
    public List<Lesson> Lessons { get; set; }
    public bool IsDeleted { get; set; }    
}