namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstruments() : IQuery<Entity.WritingInstrument[]>
{
    public class Handler : QueryHandler<GetWritingInstruments, Entity.WritingInstrument[]>
    {
        private readonly IDomainRepository<Entity.WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<Entity.WritingInstrument[]> Handle(GetWritingInstruments query)
            => (await _writingInstrumentRepository.GetAll())
                    .ToArray();
    }
}
