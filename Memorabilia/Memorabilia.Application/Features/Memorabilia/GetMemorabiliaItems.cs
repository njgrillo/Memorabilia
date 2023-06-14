namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItems() 
    : IQuery<Entity.Memorabilia[]>
{
    public class Handler : QueryHandler<GetMemorabiliaItems, Entity.Memorabilia[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository, 
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Memorabilia[]> Handle(GetMemorabiliaItems query)
            => await _memorabiliaRepository.GetAll(_applicationStateService.CurrentUser.Id);
    }
}
