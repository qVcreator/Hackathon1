namespace UwULearn2.API.Models.Responses;

public class CourseProgressResponse
{
    public int Id { get; set; }
    public UserResponse User { get; set; }
    public List<CourseResponse> FinishedCourses { get; set; }
    public List<TaskResponse> FinishedTasks { get; set; }
}
