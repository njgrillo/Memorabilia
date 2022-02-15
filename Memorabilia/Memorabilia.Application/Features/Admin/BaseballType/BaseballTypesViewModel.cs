using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.BaseballType
{
    public class BaseballTypesViewModel : DomainsViewModel
    {
        public BaseballTypesViewModel() { }

        public BaseballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Baseball Type";

        public override string PageTitle => "Baseball Types";

        public override string RoutePrefix => "BaseballTypes";
    }
}