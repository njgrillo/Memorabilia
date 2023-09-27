namespace Memorabilia.Application.Features.UserMessage;

public class AddUserMessage
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IUserMessageRepository userMessageRepository)
        {
            _applicationStateService = applicationStateService;
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.UserMessage userMessage = new(command.Subject,
                                                 Constant.UserMessageStatus.New.Id);

            userMessage.AddReply(_applicationStateService.CurrentUser.Id, 
                                 command.CreatedDate, 
                                 command.Message,
                                 command.ReceiverUserId,
                                 _applicationStateService.CurrentUser.Id,
                                 Constant.UserMessageStatus.New.Id);

            Entity.UserMessageReply userMessageReply
                = userMessage.Replies.Last();

            foreach (string imageFileName in command.ImageFileNames)
            {
                userMessageReply.AddImage(imageFileName);
            }

            await _userMessageRepository.Add(userMessage);

            command.Id = userMessage.Id;
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly UserMessageEditModel _userMessageEditModel;

        public Command(UserMessageEditModel userMessageEditModel)
        {
            _userMessageEditModel = userMessageEditModel;

            Id = _userMessageEditModel.Id;
        }

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int Id { get; set; }

        public string[] ImageFileNames
            => _userMessageEditModel.UserMessageReply
                                    .Images
                                    .Select(image => image.ImageFileName)
                                    .ToArray();

        public string Message
            => _userMessageEditModel.UserMessageReply.Message;

        public int ReceiverUserId
            => _userMessageEditModel.UserMessageReply.ReceiverUser.Id;

        public string Subject
            => _userMessageEditModel.Subject;
    }
}
