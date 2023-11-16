namespace Memorabilia.Application.Features.UserMessage;

public record SearchUserMessagesReceived(PageInfo PageInfo, string SearchText)
    : IQuery<UserMessagesModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IUserMessageRepository userMessageRepository) 
        : QueryHandler<SearchUserMessagesReceived, UserMessagesModel>
    {
        protected override async Task<UserMessagesModel> Handle(SearchUserMessagesReceived query)
        {
            PagedResult<Entity.UserMessage> result
                = await userMessageRepository.SearchReceived(query.PageInfo,
                                                             query.SearchText,
                                                             applicationStateService.CurrentUser.Id);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
