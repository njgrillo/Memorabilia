﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Sizes
{
    public class SizesViewModel : DomainsViewModel
    {
        public SizesViewModel() { }

        public SizesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Sizes";
    }
}
