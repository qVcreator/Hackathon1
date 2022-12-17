using UwULearn.Data.Enums;

namespace UwULearn.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Cat Cat { get; set; }
    public List<Course> Courses { get; set; }
    public List<int> FriendList { get; set; }
    public int Energy { get; set; }
    public Role Role { get; set; }
}