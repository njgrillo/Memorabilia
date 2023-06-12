namespace Memorabilia.Application.Features.Memorabilia.Document;

public class SaveDocument
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

            memorabilia.SetDocument(command.PersonIds,
                                    command.SizeId,
                                    command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly DocumentEditModel _editModel;

        public Command(DocumentEditModel editModel)
        {
            _editModel = editModel;
        }

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int SizeId 
            => _editModel.SizeId;

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();
    }
}
