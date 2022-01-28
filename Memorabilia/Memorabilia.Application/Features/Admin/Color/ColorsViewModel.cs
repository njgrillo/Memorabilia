using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Color
{
    public class ColorsViewModel : DomainsViewModel
    {
        public ColorsViewModel() { }

        public ColorsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Colors";
    }
}
