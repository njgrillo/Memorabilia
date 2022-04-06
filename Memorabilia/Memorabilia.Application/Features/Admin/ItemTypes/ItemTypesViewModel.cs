using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.ItemTypes
{
    public class ItemTypesViewModel : DomainsViewModel
    {
        public ItemTypesViewModel() { }

        public ItemTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Item Type";

        public override string PageTitle => "Item Types";

        public override string RoutePrefix => "ItemTypes";
    }
}