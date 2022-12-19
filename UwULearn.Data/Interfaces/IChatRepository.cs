using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface IChatRepository
{
    public Task<int> PublishMessage(AllChatMessage message);
    public Task<List<AllChatMessage>> GetMessages();
}
