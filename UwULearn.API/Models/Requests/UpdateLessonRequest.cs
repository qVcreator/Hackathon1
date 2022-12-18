namespace UwULearn2.API.Models.Requests;

public class UpdateLessonRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Text { get; set; }
    public string Video { get; set; } // url 
}
