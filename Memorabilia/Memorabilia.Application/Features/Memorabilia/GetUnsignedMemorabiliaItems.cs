namespace Memorabilia.Application.Features.Memorabilia;

public record GetUnsignedMemorabiliaItems()
    : IQuery<Entity.Memorabilia[]>
{
    public class Handler : QueryHandler<GetUnsignedMemorabiliaItems, Entity.Memorabilia[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Memorabilia[]> Handle(GetUnsignedMemorabiliaItems query)
            => await _memorabiliaRepository.GetAllUnsigned(_applicationStateService.CurrentUser.Id);
    }
}
