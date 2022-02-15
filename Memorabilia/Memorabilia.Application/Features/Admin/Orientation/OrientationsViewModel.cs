using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Orientation
{
    public class OrientationsViewModel : DomainsViewModel
    {
        public OrientationsViewModel() { }

        public OrientationsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Orientation";

        public override string PageTitle => "AOrientations";

        public override string RoutePrefix => "Orientations";
    }
}
