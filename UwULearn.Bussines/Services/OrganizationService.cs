using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizatoinRepository _organizationRepository;

    public OrganizationService(IOrganizatoinRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<int> AddOrganization(Organization newOrg)
    {
        if (await _organizationRepository.IsOrganizationExist(newOrg.Name))
            throw new Exception();

        return await _organizationRepository.AddOrganization(newOrg);
    }
}
