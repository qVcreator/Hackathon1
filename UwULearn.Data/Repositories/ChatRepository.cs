using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly UwuLearnContext _context;
    public ChatRepository(UwuLearnContext context)
    {
        _context = context;
    }
    public Task PublishMessage(AllChatMessage message)
    {
        throw new NotImplementedException();
    }
}
