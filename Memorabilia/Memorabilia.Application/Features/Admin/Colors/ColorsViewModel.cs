using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Colors
{
    public class ColorsViewModel : DomainsViewModel
    {
        public ColorsViewModel() { }

        public ColorsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Color";

        public override string PageTitle => "Colors";

        public override string RoutePrefix => "Colors";
    }
}
