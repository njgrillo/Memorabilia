namespace Memorabilia.Application.Features.UserMessage;

public record SearchUserMessagesReceived(PageInfo PageInfo, string SearchText)
    : IQuery<UserMessagesModel>
{
    public class Handler : QueryHandler<SearchUserMessagesReceived, UserMessagesModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IUserMessageRepository userMessageRepository)
        {
            _applicationStateService = applicationStateService;
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task<UserMessagesModel> Handle(SearchUserMessagesReceived query)
        {
            PagedResult<Entity.UserMessage> result
                = await _userMessageRepository.SearchReceived(query.PageInfo,
                                                              query.SearchText,
                                                              _applicationStateService.CurrentUser.Id);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
