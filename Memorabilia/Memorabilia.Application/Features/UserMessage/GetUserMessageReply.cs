namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessageReply(int UserMessageReplyId)
    : IQuery<Entity.UserMessageReply>
{
    public class Handler : QueryHandler<GetUserMessageReply, Entity.UserMessageReply>
    {
        private readonly IUserMessageReplyRepository _userMessageReplyRepository;

        public Handler(IUserMessageReplyRepository userMessageReplyRepository)
        {
            _userMessageReplyRepository = userMessageReplyRepository;
        }

        protected override async Task<Entity.UserMessageReply> Handle(GetUserMessageReply query)
            => await _userMessageReplyRepository.Get(query.UserMessageReplyId);
    }
}
