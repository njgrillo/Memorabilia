using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes
{
    public class AcquisitionTypesViewModel : DomainsViewModel
    {
        public AcquisitionTypesViewModel() { }

        public AcquisitionTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Acquisition Type";

        public override string PageTitle => "Acquisition Types";

        public override string RoutePrefix => "AcquisitionTypes";
    }
}
