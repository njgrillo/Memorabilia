namespace Memorabilia.Application.Features.Collection;

[AuthorizeByPermission(Enum.Permission.Collection)]
public class SaveCollection
{
    public class Handler(ICollectionRepository collectionRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Collection collection;

            if (command.IsNew)
            {
                collection = new Entity.Collection(command.Name,
                                                   command.Description,
                                                   command.UserId,
                                                   command.MemorabiliaIds);

                await collectionRepository.Add(collection);

                command.Id = collection.Id;

                return;
            }

            collection = await collectionRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await collectionRepository.Delete(collection);

                return;
            }

            collection.Set(command.Name,
                           command.Description,
                           command.MemorabiliaIds);

            await collectionRepository.Update(collection);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly CollectionEditModel _editModel;

        public Command(CollectionEditModel editModel)
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

        public int[] MemorabiliaIds 
            => _editModel.Items
                         .Select(item => item.MemorabiliaId)
                         .ToArray();

        public string Name 
            => _editModel.Name;

        public int UserId 
            => _editModel.UserId;
    }
}
