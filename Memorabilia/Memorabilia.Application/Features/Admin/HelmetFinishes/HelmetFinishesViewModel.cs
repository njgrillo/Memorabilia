using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes
{
    public class HelmetFinishesViewModel : DomainsViewModel
    {
        public HelmetFinishesViewModel() { }

        public HelmetFinishesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Helmet Finish";

        public override string PageTitle => "Helmet Finishes";

        public override string RoutePrefix => "HelmetFinishes";
    }
}
