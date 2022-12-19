using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface IChatService
{
    public Task<int> PublishMessage(AllChatMessage message);
    public Task<List<AllChatMessage>> GetMessages();
}
