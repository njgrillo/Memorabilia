namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class SaveCompactDisc
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

            memorabilia.SetCompactDisc(command.PersonIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly CompactDiscEditModel _editModel;

        public Command(CompactDiscEditModel editModel)
        {
            _editModel = editModel;
        }

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();
    }
}
