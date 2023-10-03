namespace Memorabilia.Application.Features.Admin.WritingInstruments;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetWritingInstrument(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetWritingInstrument, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetWritingInstrument query)
            => await _writingInstrumentRepository.Get(query.Id);
    }
}
