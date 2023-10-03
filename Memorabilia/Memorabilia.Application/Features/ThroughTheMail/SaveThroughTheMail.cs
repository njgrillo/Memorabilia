namespace Memorabilia.Application.Features.ThroughTheMail;

[AuthorizeByPermission(Enum.Permission.ThroughTheMail)]
public class SaveThroughTheMail
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IThroughTheMailRepository _throughTheMailRepository;

        public Handler(IThroughTheMailRepository throughTheMailRepository)
        {
            _throughTheMailRepository = throughTheMailRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.ThroughTheMail throughTheMail;

            if (command.IsNew)
            {
                throughTheMail = new Entity.ThroughTheMail(command.PersonId,
                                                           command.AddressId,
                                                           command.SentDate,
                                                           command.ReceivedDate,
                                                           command.Notes,
                                                           command.ThroughTheMailFailureTypeId,
                                                           command.UserId);

                SetMemorabilia(throughTheMail, command);

                await _throughTheMailRepository.Add(throughTheMail);

                command.Id = throughTheMail.Id;

                return;
            }

            throughTheMail = await _throughTheMailRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _throughTheMailRepository.Delete(throughTheMail);

                return;
            }

            throughTheMail.Set(command.AddressId,
                               command.SentDate,
                               command.ReceivedDate,                               
                               command.Notes,
                               command.ThroughTheMailFailureTypeId);

            DeleteMemorabilia(throughTheMail, command);
            SetMemorabilia(throughTheMail, command);

            await _throughTheMailRepository.Update(throughTheMail);
        }

        private static void DeleteMemorabilia(Entity.ThroughTheMail throughTheMail, Command command)
        {
            if (!command.DeleteMemorabiliaIds.Any())
                return;

            throughTheMail.RemoveMemorabilia(command.DeleteMemorabiliaIds);
        }

        private static void SetMemorabilia(Entity.ThroughTheMail throughTheMail, Command command)
        {
            foreach (ThroughTheMailMemorabiliaEditModel throughTheMailMemorabilia in command.Memorabilia.Where(item => !item.IsDeleted))
            {
                throughTheMail.SetMemorabilia(throughTheMailMemorabilia.Id,
                                              throughTheMailMemorabilia.ThroughTheMailId,
                                              throughTheMailMemorabilia.MemorabiliaId,
                                              throughTheMailMemorabilia.AutographId,
                                              throughTheMailMemorabilia.Cost,
                                              throughTheMailMemorabilia.IsExtraReceived);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly ThroughTheMailEditModel _editModel;

        public Command(ThroughTheMailEditModel editModel)
        {
            _editModel = editModel;
            Id = _editModel.Id;
        }

        public int? AddressId
            => _editModel.AddressId;

        public int[] DeleteMemorabiliaIds
            => _editModel.Memorabilia
                         .Where(throughTheMailMemorabilia => throughTheMailMemorabilia.IsDeleted)
                         .Select(throughTheMailMemorabilia => throughTheMailMemorabilia.MemorabiliaId)
                         .ToArray();

        public int Id { get; set; }

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public ThroughTheMailMemorabiliaEditModel[] Memorabilia
            => _editModel.Memorabilia
                         .ToArray();

        public string Notes
            => _editModel.Notes;

        public int PersonId
            => _editModel.Person.Id;

        public DateTime? ReceivedDate
            => _editModel.ReceivedDate;

        public DateTime? SentDate
            => _editModel.SentDate;

        public int? ThroughTheMailFailureTypeId
            => _editModel.ThroughTheMailFailureTypeId;

        public int UserId
            => _editModel.UserId;
    }
}
