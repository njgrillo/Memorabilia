using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges
{
    public class CollegesViewModel : DomainsViewModel
    {
        public CollegesViewModel() { }

        public CollegesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "College";

        public override string PageTitle => "Colleges";

        public override string RoutePrefix => "Colleges";
    }
}
