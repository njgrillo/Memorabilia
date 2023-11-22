namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetReceivedThroughTheMailsCount()
    : IQuery<int>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IThroughTheMailRepository throughTheMailRepository)
        : QueryHandler<GetReceivedThroughTheMailsCount, int>
    {
        protected override async Task<int> Handle(GetReceivedThroughTheMailsCount query)
            => await throughTheMailRepository.GetAllReceivedCount(applicationStateService.CurrentUser.Id);
    }
}
