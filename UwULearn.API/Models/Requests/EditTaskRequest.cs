namespace UwULearn2.API.Models.Requests;

public class EditTaskRequest
{
    public string Descriotion { get; set; }
    public string Example { get; set; }
    public string CorrectAnswer { get; set; }
    public int Reward { get; set; }
}
