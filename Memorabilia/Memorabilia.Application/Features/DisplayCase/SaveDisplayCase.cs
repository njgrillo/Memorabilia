namespace Memorabilia.Application.Features.DisplayCase;

[AuthorizeByPermission(Enum.Permission.DisplayCases)]
public class SaveDisplayCase
{
    public class Handler(IDisplayCaseRepository displayCaseRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.DisplayCase displayCase;

            if (command.IsNew)
            {
                displayCase = new Entity.DisplayCase(
                    command.Description,
                    command.Name,
                    command.PrivacyTypeId,
                    command.UserId);

                SetMemorabilia(command, displayCase);

                await displayCaseRepository.Add(displayCase);

                command.Id = displayCase.Id;

                return;
            }

            displayCase = await displayCaseRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await displayCaseRepository.Delete(displayCase);

                return;
            }

            displayCase.Set(
                command.Description,
                command.Name,
                command.PrivacyTypeId);

            SetMemorabilia(command, displayCase);

            await displayCaseRepository.Update(displayCase);
        }

        private static void SetMemorabilia(Command command, Entity.DisplayCase displayCase)
        {
            foreach (DisplayCaseMemorabiliaEditModel displayCaseMemorabilia in command.Memorabilias)
            {
                displayCase.SetMemorabilia(displayCaseMemorabilia.Memorabilia.Id,
                                           displayCaseMemorabilia.XPosition,
                                           displayCaseMemorabilia.YPosition,
                                           displayCaseMemorabilia.IsDeleted);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly DisplayCaseEditModel _editModel;

        public Command(DisplayCaseEditModel editModel)
        {
            _editModel = editModel;
            Id = _editModel.Id;
        }

        public string Description
            => _editModel.Description;

        public int Id { get; set; }

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public string Name
            => _editModel.Name;

        public DisplayCaseMemorabiliaEditModel[] Memorabilias
            => _editModel.Memorabilias.ToArray();

        public int PrivacyTypeId
            => _editModel.PrivacyTypeId;

        public int UserId
            => _editModel.UserId;
    }
}
