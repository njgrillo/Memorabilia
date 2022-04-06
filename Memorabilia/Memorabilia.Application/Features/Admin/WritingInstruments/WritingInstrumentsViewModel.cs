using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.WritingInstruments
{
    public class WritingInstrumentsViewModel : DomainsViewModel
    {
        public WritingInstrumentsViewModel() { }

        public WritingInstrumentsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Writing Instrument";

        public override string PageTitle => "Writing Instruments";

        public override string RoutePrefix => "WritingInstruments";
    }
}
