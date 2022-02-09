using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.PhotoType
{
    public class PhotoTypesViewModel : DomainsViewModel
    {
        public PhotoTypesViewModel() { }

        public PhotoTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Photo Types";
    }
}
