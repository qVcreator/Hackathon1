namespace UwULearn.Data.Entities;

public class CourseProgress
{
    public int Id { get; set; }
    public User User { get; set; }
    public List<Course> FinishedCourses { get; set; }
    public List<Task> FinishedTasks { get; set; }
}
