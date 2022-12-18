namespace UwULearn2.API.Models.Requests;

public class AddAdminRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string OrganizatonName { get; set; }
    public string OrganizatonPicture { get; set; }
    public string OrganizatonCollor { get; set; }
    public string CatName { get; set; }
}
