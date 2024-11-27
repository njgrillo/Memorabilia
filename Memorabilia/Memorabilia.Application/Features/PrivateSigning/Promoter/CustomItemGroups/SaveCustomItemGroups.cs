namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public class SaveCustomItemGroups
{
    public class Handler(IUserRepository userRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.User user = await userRepository.Get(command.UserId);

            foreach (CustomItemGroupEditModel customItemGroup in command.CustomItemGroups.Where(x => !x.IsDeleted))
            {
                Entity.PrivateSigningCustomItemTypeGroup[] customItemTypeGroups
                    = customItemGroup.Items
                                     .Where(x => !x.IsDeleted)
                                     .Select(x => new Entity.PrivateSigningCustomItemTypeGroup(
                                                 x.Id, 
                                                 x.ItemType.Id, 
                                                 x.PrivateSigningCustomItemGroupId
                                                 )
                                             )
                                     .ToArray();

                user.SetPrivateSigningCustomItemGroups(
                    customItemGroup.Id,
                    customItemGroup.Name,
                    customItemTypeGroups
                    );

                int[] deletedCustomItemTypeGroupIds
                    = customItemGroup.Items
                                     .Where(x => x.IsDeleted)
                                     .Select(x => x.Id)
                                     .ToArray();

                if (deletedCustomItemTypeGroupIds.Length == 0)
                    continue;

                user.RemovePrivateSigningCustomItemTypeGroups(customItemGroup.Id, deletedCustomItemTypeGroupIds);
            }

            foreach (CustomItemGroupEditModel customItemGroup in command.CustomItemGroups.Where(x => !x.IsNew && x.IsDeleted))
            {
                user.RemovePrivateSigningCustomItemGroups(customItemGroup.Id);
            }

            await userRepository.Update(user);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly CustomItemGroupsEditModel _editModel;

        public Command(CustomItemGroupsEditModel editModel)
        {
            _editModel = editModel;
        }

        public CustomItemGroupEditModel[] CustomItemGroups
            => _editModel.CustomItemGroups.Count > 0
                ? _editModel.CustomItemGroups.ToArray()
                : [];

        public int UserId
            => _editModel.UserId;
    }
}
