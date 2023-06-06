namespace Memorabilia.Application.Features.Collection;

public class SaveCollection
{
    public class Handler : CommandHandler<Command>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.Collection collection;

            if (command.IsNew)
            {
                collection = new Entity.Collection(command.Name,
                                                   command.Description,
                                                   command.UserId,
                                                   command.MemorabiliaIds);

                await _collectionRepository.Add(collection);

                command.Id = collection.Id;

                return;
            }

            collection = await _collectionRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _collectionRepository.Delete(collection);

                return;
            }

            collection.Set(command.Name,
                           command.Description,
                           command.MemorabiliaIds);

            await _collectionRepository.Update(collection);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly CollectionEditModel _viewModel;

        public Command(CollectionEditModel viewModel)
        {
            _viewModel = viewModel;
            Id = _viewModel.Id;
        }

        public string Description => _viewModel.Description;

        public int Id { get; set; }

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public int[] MemorabiliaIds 
            => _viewModel.Items.Select(item => item.MemorabiliaId).ToArray();

        public string Name => _viewModel.Name;

        public int UserId => _viewModel.UserId;
    }
}
