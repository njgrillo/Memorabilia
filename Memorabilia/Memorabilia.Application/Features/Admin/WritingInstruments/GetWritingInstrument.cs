namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstrument(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository) 
        : QueryHandler<GetWritingInstrument, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetWritingInstrument query)
            => await writingInstrumentRepository.Get(query.Id);
    }
}
