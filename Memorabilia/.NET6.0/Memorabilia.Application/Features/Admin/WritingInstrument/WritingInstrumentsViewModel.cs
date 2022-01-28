using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstrument
{
    public class WritingInstrumentsViewModel : DomainsViewModel
    {
        public WritingInstrumentsViewModel() { }

        public WritingInstrumentsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Writing Instruments";
    }
}
