namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessagesSent(PageInfo PageInfo, int? UserMessageStatusId = null)
    : IQuery<UserMessagesModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IUserMessageRepository userMessageRepository) 
        : QueryHandler<GetUserMessagesSent, UserMessagesModel>
    {
        protected override async Task<UserMessagesModel> Handle(GetUserMessagesSent query)
        {
            PagedResult<Entity.UserMessage> result
                = await userMessageRepository.GetAllSent(query.PageInfo, 
                                                         applicationStateService.CurrentUser.Id, 
                                                         query.UserMessageStatusId);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
