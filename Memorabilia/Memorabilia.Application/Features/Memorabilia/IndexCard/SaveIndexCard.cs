namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class SaveIndexCard
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

            memorabilia.SetIndexCard(command.SizeId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly IndexCardEditModel _editModel;

        public Command(IndexCardEditModel editModel)
        {
            _editModel = editModel;
        }

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int SizeId 
            => _editModel.SizeId;
    }
}
