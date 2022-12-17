using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface IChatRepository
{
    public Task PublishMessage(AllChatMessage message);
}
