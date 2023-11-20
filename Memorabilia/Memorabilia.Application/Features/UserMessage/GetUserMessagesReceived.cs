namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessagesReceived(PageInfo PageInfo, int? UserMessageStatusId = null)
    : IQuery<UserMessagesModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IUserMessageRepository userMessageRepository) 
        : QueryHandler<GetUserMessagesReceived, UserMessagesModel>
    {
        protected override async Task<UserMessagesModel> Handle(GetUserMessagesReceived query)
        {
            PagedResult<Entity.UserMessage> result
                = await userMessageRepository.GetAllReceived(query.PageInfo,
                                                             applicationStateService.CurrentUser.Id,
                                                             query.UserMessageStatusId);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
