namespace Memorabilia.Application.Features.Memorabilia.Book;

public class SaveBook
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBook(command.Edition,
                                command.HardCover,
                                command.PersonIds,
                                command.Publisher,
                                command.SportIds,
                                command.TeamIds,
                                command.Title);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly BookEditModel _editModel;

        public Command(BookEditModel editModel)
        {
            _editModel = editModel;
        }

        public string Edition 
            => _editModel.Edition;

        public bool HardCover 
            => _editModel.HardCover;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public string Publisher 
            => _editModel.Publisher;

        public int[] SportIds 
            => _editModel.SportIds.ToArray();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();

        public string Title 
            => _editModel.Title;
    }
}
