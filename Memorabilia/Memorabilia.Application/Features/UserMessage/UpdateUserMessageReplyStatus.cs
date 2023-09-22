namespace Memorabilia.Application.Features.UserMessage;

public record UpdateUserMessageReplyStatus(int UserMessageReplyId, int UserMessageStatusId)
    : ICommand
{
    public class Handler : CommandHandler<UpdateUserMessageReplyStatus>
    {
        private readonly IUserMessageReplyRepository _userMessageReplyRepository;

        public Handler(IUserMessageReplyRepository userMessageReplyRepository)
        {
            _userMessageReplyRepository = userMessageReplyRepository;
        }

        protected override async Task Handle(UpdateUserMessageReplyStatus command)
        {
            Entity.UserMessageReply userMessageReply
                = await _userMessageReplyRepository.Get(command.UserMessageReplyId);

            userMessageReply.SetStatus(command.UserMessageStatusId);

            await _userMessageReplyRepository.Update(userMessageReply);
        }
    }
}
