using UwULearn.Data.Entities;

namespace UwULearn2.API.Models.Requests;

public class AddCourseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Lesson> Lessons { get; set; } // LessonRequest later
}
