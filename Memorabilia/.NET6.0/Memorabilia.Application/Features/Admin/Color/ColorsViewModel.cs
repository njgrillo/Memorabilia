using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Color
{
    public class ColorsViewModel : DomainsViewModel
    {
        public ColorsViewModel() { }

        public ColorsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Colors";
    }
}
