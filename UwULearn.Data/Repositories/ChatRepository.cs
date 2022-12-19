using Microsoft.EntityFrameworkCore;
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

    public async Task<List<AllChatMessage>> GetMessages()
    {
        return await _context.AllChatMessages
            .Include(c => c.From)
            .Where(q => q.Date >= q.Date.AddHours(-1))
            .ToListAsync();
    }

    public async Task<int> PublishMessage(AllChatMessage message)
    {
        await _context.AllChatMessages.AddAsync(message);
        await _context.SaveChangesAsync();
        return message.Id;
    }
}
