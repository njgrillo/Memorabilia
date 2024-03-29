﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Size
{
    public class SizesViewModel : DomainsViewModel
    {
        public SizesViewModel() { }

        public SizesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Sizes";
    }
}
