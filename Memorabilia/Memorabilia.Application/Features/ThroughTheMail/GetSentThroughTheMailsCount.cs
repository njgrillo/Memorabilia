namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetSentThroughTheMailsCount()
    : IQuery<int>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IThroughTheMailRepository throughTheMailRepository)
        : QueryHandler<GetSentThroughTheMailsCount, int>
    {
        protected override async Task<int> Handle(GetSentThroughTheMailsCount query)
            => await throughTheMailRepository.GetAllSentCount(applicationStateService.CurrentUser.Id);
    }
}
