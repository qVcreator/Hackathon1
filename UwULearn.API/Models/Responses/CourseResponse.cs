namespace UwULearn2.API.Models.Responses;

public class CourseResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<LessonResponse> Lessons { get; set; }
}
