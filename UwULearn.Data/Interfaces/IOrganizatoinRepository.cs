using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface IOrganizatoinRepository
{
    public Task<int> AddOrganization(Organization newOrg);
    public Task<bool> IsOrganizationExist(string orgName);
}
