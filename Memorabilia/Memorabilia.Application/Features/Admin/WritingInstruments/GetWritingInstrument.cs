namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstrument(int Id) : IQuery<Entity.WritingInstrument>
{
    public class Handler : QueryHandler<GetWritingInstrument, Entity.WritingInstrument>
    {
        private readonly IDomainRepository<Entity.WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<Entity.WritingInstrument> Handle(GetWritingInstrument query)
            => await _writingInstrumentRepository.Get(query.Id);
    }
}
