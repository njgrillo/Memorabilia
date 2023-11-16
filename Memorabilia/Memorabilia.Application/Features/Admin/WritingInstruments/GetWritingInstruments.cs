namespace Memorabilia.Application.Features.Admin.WritingInstruments;

public record GetWritingInstruments() : IQuery<Entity.WritingInstrument[]>
{
    public class Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository) 
        : QueryHandler<GetWritingInstruments, Entity.WritingInstrument[]>
    {
        protected override async Task<Entity.WritingInstrument[]> Handle(GetWritingInstruments query)
            => await writingInstrumentRepository.GetAll();
    }
}
