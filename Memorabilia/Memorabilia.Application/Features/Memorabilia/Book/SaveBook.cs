namespace Memorabilia.Application.Features.Memorabilia.Book;

public class SaveBook
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBook(command.Edition,
                                command.HardCover,
                                command.PersonIds,
                                command.Publisher,
                                command.SportIds,
                                command.TeamIds,
                                command.Title);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(BookEditModel editModel) 
        : DomainCommand, ICommand
    {
        public string Edition 
            => editModel.Edition;

        public bool HardCover 
            => editModel.HardCover;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People
                        .ActiveIds();

        public string Publisher 
            => editModel.Publisher;

        public int[] SportIds 
            => editModel.SportIds
                        .ToArray();

        public int[] TeamIds 
            => editModel.Teams
                        .ActiveIds();

        public string Title 
            => editModel.Title;
    }
}
