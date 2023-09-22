namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessages(PageInfo PageInfo, int? UserMessageStatusId = null)
    : IQuery<UserMessagesModel>
{
    public class Handler : QueryHandler<GetUserMessages, UserMessagesModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IUserMessageRepository userMessageRepository)
        {
            _applicationStateService = applicationStateService;
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task<UserMessagesModel> Handle(GetUserMessages query)
        {
            PagedResult<Entity.UserMessage> result
                = await _userMessageRepository.GetAll(query.PageInfo, 
                                                      _applicationStateService.CurrentUser.Id, 
                                                      query.UserMessageStatusId);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
