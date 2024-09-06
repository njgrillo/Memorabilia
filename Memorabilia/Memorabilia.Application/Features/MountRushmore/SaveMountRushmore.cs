namespace Memorabilia.Application.Features.MountRushmore;

//TODO
[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveMountRushmore
{
    public class Handler(IMountRushmoreRepository mountRushmoreRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.MountRushmore mountRushmore;

            if (command.IsNew)
            {
                mountRushmore = new Entity.MountRushmore(
                    command.Description,
                    command.Name,
                    command.PrivacyTypeId,
                    command.UserId);

                SetPeople(command, mountRushmore);

                await mountRushmoreRepository.Add(mountRushmore);

                command.Id = mountRushmore.Id;

                return;
            }

            mountRushmore = await mountRushmoreRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await mountRushmoreRepository.Delete(mountRushmore);

                return;
            }

            mountRushmore.Set(
                command.Description,
                command.Name,
                command.PrivacyTypeId);

            SetPeople(command, mountRushmore);

            await mountRushmoreRepository.Update(mountRushmore);
        }

        private static void SetPeople(Command command, Entity.MountRushmore mountRushmore)
        {
            foreach (MountRushmorePersonEditModel mountRushmorePerson in command.People)
            {
                mountRushmore.SetPerson(mountRushmorePerson.PersonId,
                                        mountRushmorePerson.PositionId,
                                        mountRushmorePerson.IsDeleted);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly MountRushmoreEditModel _editModel;

        public Command(MountRushmoreEditModel editModel)
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

        public MountRushmorePersonEditModel[] People
            => _editModel.People.ToArray();   

        public int PrivacyTypeId
            => _editModel.PrivacyTypeId;

        public int UserId
            => _editModel.UserId;
    }
}
