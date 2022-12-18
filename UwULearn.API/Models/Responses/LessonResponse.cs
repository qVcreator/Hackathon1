namespace UwULearn2.API.Models.Responses;

public class LessonResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Text { get; set; }
    public string Video { get; set; } // url 
    public TaskResponse Task { get; set; }
}
