namespace Memorabilia.Application.Features.Memorabilia;

public record GetUnsignedMemorabiliaItems()
    : IQuery<Entity.Memorabilia[]>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetUnsignedMemorabiliaItems, Entity.Memorabilia[]>
    {
        protected override async Task<Entity.Memorabilia[]> Handle(GetUnsignedMemorabiliaItems query)
            => await memorabiliaRepository.GetAllUnsigned(applicationStateService.CurrentUser.Id);
    }
}
