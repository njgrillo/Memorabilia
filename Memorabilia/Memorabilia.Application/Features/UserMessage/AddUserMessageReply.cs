using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.UserMessage;

public class AddUserMessageReply
{
    public class Handler(IApplicationStateService applicationStateService,
                         IUserMessageRepository userMessageRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.UserMessage userMessage 
                = await userMessageRepository.Get(command.UserMessageId);

            userMessage.AddReply(applicationStateService.CurrentUser.Id,
                                 command.CreatedDate,
                                 command.Message,
                                 command.ReceiverUserId,
                                 command.SenderUserId,
                                 Constant.UserMessageStatus.New.Id);

            Entity.UserMessageReply userMessageReply
                = userMessage.Replies.Last();

            foreach (UserMessageReplyImageEditModel image in command.Images)
            {
                userMessageReply.AddImage(image.ImageFileName);
            }

            await userMessageRepository.Update(userMessage);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly UserMessageReplyEditModel _userMessageReplyEditModel;

        public Command(UserMessageReplyEditModel userMessageReplyEditModel)
        {
            _userMessageReplyEditModel = userMessageReplyEditModel;

            Id = _userMessageReplyEditModel.Id;
        }

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int Id { get; set; }

        public UserMessageReplyImageEditModel[] Images
            => _userMessageReplyEditModel.Images
                                         .ToArray();

        public string Message
            => _userMessageReplyEditModel.Message;

        public int ReceiverUserId
            => _userMessageReplyEditModel.ReceiverUserId;

        public int SenderUserId
            => _userMessageReplyEditModel.SenderUserId;

        public int UserMessageId
            => _userMessageReplyEditModel.UserMessageId;

        public int UserMessageStatusId
            => _userMessageReplyEditModel.UserMessageStatusId;
    }
}
