namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItem(int Id) 
    : IQuery<Entity.Memorabilia>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetMemorabiliaItem, Entity.Memorabilia>
    {
        protected override async Task<Entity.Memorabilia> Handle(GetMemorabiliaItem query)
            => await memorabiliaRepository.Get(query.Id);
    }
}
