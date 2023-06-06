using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin;

public class DomainsViewModel : Model
{
    public DomainsViewModel() { }

    public DomainsViewModel(IEnumerable<DomainEntity> domainEntities)
    {
        DomainEntities = domainEntities.Select(domainEntity => new DomainViewModel(domainEntity)).ToList();
    }

    public List<DomainViewModel> DomainEntities { get; set; } = new();        
}
