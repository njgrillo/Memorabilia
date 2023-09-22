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
            Entity.UserMessage userMessage = new(_applicationStateService.CurrentUser.Id,
                                                 command.CreatedDate,
                                                 command.ReceiverUserId,
                                                 command.SenderUserId,
                                                 command.Subject);

            userMessage.AddReply(_applicationStateService.CurrentUser.Id, 
                                 command.CreatedDate, 
                                 command.Message,
                                 command.ReceiverUserId,
                                 command.SenderUserId,
                                 Constant.UserMessageStatus.New.Id);

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

        public string Message
            => _userMessageEditModel.Message;

        public int ReceiverUserId
            => _userMessageEditModel.ReceiverUserId;

        public int SenderUserId
            => _userMessageEditModel.SenderUserId;

        public string Subject
            => _userMessageEditModel.Subject;
    }
}
