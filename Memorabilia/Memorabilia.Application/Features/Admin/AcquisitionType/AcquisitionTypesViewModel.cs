using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AcquisitionType
{
    public class AcquisitionTypesViewModel : DomainsViewModel
    {
        public AcquisitionTypesViewModel() { }

        public AcquisitionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Acquisition Types";
    }
}
