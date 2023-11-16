namespace Memorabilia.Application.Features.Memorabilia;

public record GetSelectMemorabiliaItem(int Id) 
    : IQuery<Entity.Memorabilia>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetSelectMemorabiliaItem, Entity.Memorabilia>
    {
        protected override async Task<Entity.Memorabilia> Handle(GetSelectMemorabiliaItem query)
            => await memorabiliaRepository.Get(query.Id);
    }
}
