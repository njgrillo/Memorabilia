namespace Memorabilia.Application.Features.ForSale;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record HasItemsForSale() : IQuery<bool>
{
    public class Handler : QueryHandler<HasItemsForSale, bool>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<bool> Handle(HasItemsForSale query)
            => await _memorabiliaRepository.HasItemsForSale(_applicationStateService.CurrentUser.Id);
    }
}
