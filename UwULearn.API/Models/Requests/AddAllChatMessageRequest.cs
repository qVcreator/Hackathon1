namespace UwULearn2.API.Models.Requests
{
    public class AddAllChatMessageRequest
    {
        public int From { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
