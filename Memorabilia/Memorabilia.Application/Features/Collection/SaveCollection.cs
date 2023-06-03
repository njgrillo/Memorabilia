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
            Domain.Entities.Collection collection;

            if (command.IsNew)
            {
                collection = new Domain.Entities.Collection(command.Name,
                                                            command.Description,
                                                            command.UserId);

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
                           command.Description);

            await _collectionRepository.Update(collection);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveCollectionViewModel _viewModel;

        public Command(SaveCollectionViewModel viewModel)
        {
            _viewModel = viewModel;
            Id = _viewModel.Id;
        }

        public string Description => _viewModel.Description;

        public int Id { get; set; }

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public string Name => _viewModel.Name;

        public int UserId => _viewModel.UserId;
    }
}
