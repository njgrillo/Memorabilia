namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetReceivedThroughTheMails(PageInfo PageInfo)
    : IQuery<ThroughTheMailsModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IThroughTheMailRepository throughTheMailRepository)
        : QueryHandler<GetReceivedThroughTheMails, ThroughTheMailsModel>
    {
        protected override async Task<ThroughTheMailsModel> Handle(GetReceivedThroughTheMails query)
        {
            PagedResult<Entity.ThroughTheMail> result
                = await throughTheMailRepository.GetAllReceived(query.PageInfo, applicationStateService.CurrentUser.Id);

            return new ThroughTheMailsModel(result.Data, result.PageInfo);
        }
    }
}
