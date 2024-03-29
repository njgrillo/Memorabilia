﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemType
{
    public class ItemTypesViewModel : DomainsViewModel
    {
        public ItemTypesViewModel() { }

        public ItemTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Item Types";
    }
}