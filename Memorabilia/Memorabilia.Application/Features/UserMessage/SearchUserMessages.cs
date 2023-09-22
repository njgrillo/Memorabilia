namespace Memorabilia.Application.Features.UserMessage;

public record SearchUserMessages(PageInfo PageInfo, string SearchText)
    : IQuery<UserMessagesModel>
{
    public class Handler : QueryHandler<SearchUserMessages, UserMessagesModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IUserMessageRepository userMessageRepository)
        {
            _applicationStateService = applicationStateService;
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task<UserMessagesModel> Handle(SearchUserMessages query)
        {
            PagedResult<Entity.UserMessage> result
                = await _userMessageRepository.Search(query.PageInfo, query.SearchText, _applicationStateService.CurrentUser.Id);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
