using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class OrganizationRepository : IOrganizatoinRepository
{
    private readonly UwuLearnContext _context;

    public OrganizationRepository(UwuLearnContext context)
    {
        _context = context;
    }

    public async Task<int> AddOrganization(Organization newOrg)
    {
        await _context.AddAsync(newOrg);
        await _context.SaveChangesAsync();
        return newOrg.Id;
    }

    public async Task<bool> IsOrganizationExist(string orgName)
    {
        return false;
    }
}
