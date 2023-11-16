namespace Memorabilia.Application.Features.UserMessage;

public record UpdateUserMessageReplyStatus(int UserMessageReplyId, int UserMessageStatusId)
    : ICommand
{
    public class Handler(IUserMessageReplyRepository userMessageReplyRepository) 
        : CommandHandler<UpdateUserMessageReplyStatus>
    {
        protected override async Task Handle(UpdateUserMessageReplyStatus command)
        {
            Entity.UserMessageReply userMessageReply
                = await userMessageReplyRepository.Get(command.UserMessageReplyId);

            userMessageReply.SetStatus(command.UserMessageStatusId);

            await userMessageReplyRepository.Update(userMessageReply);
        }
    }
}
