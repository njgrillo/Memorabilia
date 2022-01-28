﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.MagazineType
{
    public class MagazineTypesViewModel : DomainsViewModel
    {
        public MagazineTypesViewModel() { }

        public MagazineTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Magazine Types";
    }
}
