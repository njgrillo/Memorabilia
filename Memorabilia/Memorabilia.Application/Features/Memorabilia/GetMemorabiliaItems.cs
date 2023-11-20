namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItems() 
    : IQuery<Entity.Memorabilia[]>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetMemorabiliaItems, Entity.Memorabilia[]>
    {
        protected override async Task<Entity.Memorabilia[]> Handle(GetMemorabiliaItems query)
            => await memorabiliaRepository.GetAll(applicationStateService.CurrentUser.Id);
    }
}
