using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstrument(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetWritingInstrument, DomainModel>
    {
        private readonly IDomainRepository<WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<DomainModel> Handle(GetWritingInstrument query)
        {
            return new DomainModel(await _writingInstrumentRepository.Get(query.Id));
        }
    }
}
