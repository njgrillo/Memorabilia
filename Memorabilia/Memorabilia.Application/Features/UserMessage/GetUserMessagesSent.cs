namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessagesSent(PageInfo PageInfo, int? UserMessageStatusId = null)
    : IQuery<UserMessagesModel>
{
    public class Handler : QueryHandler<GetUserMessagesSent, UserMessagesModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IUserMessageRepository userMessageRepository)
        {
            _applicationStateService = applicationStateService;
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task<UserMessagesModel> Handle(GetUserMessagesSent query)
        {
            PagedResult<Entity.UserMessage> result
                = await _userMessageRepository.GetAllSent(query.PageInfo, 
                                                          _applicationStateService.CurrentUser.Id, 
                                                          query.UserMessageStatusId);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
