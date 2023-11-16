namespace Memorabilia.Application.Features.Admin;

public class DomainsModel : Model
{
    public DomainsModel() { }

    public DomainsModel(IEnumerable<Entity.DomainEntity> domainEntities)
    {
        DomainEntities = domainEntities.Select(domainEntity => new DomainModel(domainEntity))
                                       .ToList();
    }

    public List<DomainModel> DomainEntities { get; set; } 
        = [];        
}
