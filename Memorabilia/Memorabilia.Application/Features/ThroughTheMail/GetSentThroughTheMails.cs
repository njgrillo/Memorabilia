namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetSentThroughTheMails(PageInfo PageInfo)
    : IQuery<ThroughTheMailsModel>
{
    public class Handler(IApplicationStateService applicationStateService, 
                         IThroughTheMailRepository throughTheMailRepository)
        : QueryHandler<GetSentThroughTheMails, ThroughTheMailsModel>
    {
        protected override async Task<ThroughTheMailsModel> Handle(GetSentThroughTheMails query)
        {
            PagedResult<Entity.ThroughTheMail> result
                = await throughTheMailRepository.GetAllSent(query.PageInfo, applicationStateService.CurrentUser.Id);

            return new ThroughTheMailsModel(result.Data, result.PageInfo);
        }
    }
}
