using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.ForTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record HasItemsForTrade() : IQuery<bool>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<HasItemsForTrade, bool>
    {
        protected override async Task<bool> Handle(HasItemsForTrade query)
            => await memorabiliaRepository.HasItemsForTrade(applicationStateService.CurrentUser.Id);
    }
}
