namespace Memorabilia.Application.Features.ForTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record HasItemsForTrade() : IQuery<bool>
{
    public class Handler : QueryHandler<HasItemsForTrade, bool>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<bool> Handle(HasItemsForTrade query)
            => await _memorabiliaRepository.HasItemsForTrade(_applicationStateService.CurrentUser.Id);
    }
}
