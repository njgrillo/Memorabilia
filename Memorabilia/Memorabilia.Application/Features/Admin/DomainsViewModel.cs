using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin
{
    public class DomainsViewModel : ViewModel
    {
        public DomainsViewModel() { }

        public DomainsViewModel(IEnumerable<DomainEntity> domainEntities)
        {
            DomainEntities = domainEntities.Select(domainEntity => new DomainViewModel(domainEntity)).ToList();
        }

        public List<DomainViewModel> DomainEntities { get; set; } = new();        
    }
}
