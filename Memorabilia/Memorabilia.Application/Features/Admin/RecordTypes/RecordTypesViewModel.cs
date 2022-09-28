using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes
{
    public class RecordTypesViewModel : DomainsViewModel
    {
        public RecordTypesViewModel() { }

        public RecordTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Record Type";

        public override string PageTitle => "Record Types";

        public override string RoutePrefix => "RecordTypes";
    }
}
