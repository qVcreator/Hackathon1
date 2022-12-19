using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IUsersService _usersService;

    public ChatService(IChatRepository chatRepository, IUsersService usersService)
    {
        _chatRepository = chatRepository;
        _usersService = usersService;
    }

    public async Task<List<AllChatMessage>> GetMessages()
    {
        return await _chatRepository.GetMessages();
    }

    public async Task<int> PublishMessage(AllChatMessage message)
    {
        message.From = await _usersService.GetUserById(message.From.Id);
        return await _chatRepository.PublishMessage(message);
    }
}
