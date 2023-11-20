namespace Memorabilia.Application.Features.ForSale;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record HasItemsForSale() : IQuery<bool>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<HasItemsForSale, bool>
    {
        protected override async Task<bool> Handle(HasItemsForSale query)
            => await memorabiliaRepository.HasItemsForSale(applicationStateService.CurrentUser.Id);
    }
}
