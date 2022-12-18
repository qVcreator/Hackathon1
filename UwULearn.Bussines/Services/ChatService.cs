using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;

    public ChatService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public Task<int> PublishMessage(AllChatMessage message)
    {
        throw new NotImplementedException();
    }
}
