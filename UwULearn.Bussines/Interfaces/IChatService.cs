using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface IChatService
{
    public Task PublishMessage(AllChatMessage message);
}
