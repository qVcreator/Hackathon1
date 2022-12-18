namespace UwULearn2.API.Models.Responses;

public class UserResponse
{
    public string Username { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public CatResponse Cat { get; set; }
    public List<CourseResponse> Courses { get; set; }
    public List<UserResponse> FriendList { get; set; }
    public int Energy { get; set; }
}
