using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface IOrganizationService 
{
    public Task<int> AddOrganization(Organization newOrg);
}
