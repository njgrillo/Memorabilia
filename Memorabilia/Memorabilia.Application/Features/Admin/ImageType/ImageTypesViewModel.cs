using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.ImageType
{
    public class ImageTypesViewModel : DomainsViewModel
    {
        public ImageTypesViewModel() { }

        public ImageTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Image Types";
    }
}
