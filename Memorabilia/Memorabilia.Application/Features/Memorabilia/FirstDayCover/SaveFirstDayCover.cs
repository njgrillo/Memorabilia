namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class SaveFirstDayCover
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

            memorabilia.SetFirstDayCover(command.PersonIds,
                                         command.SizeId,
                                         command.Date,
                                         command.SportIds,
                                         command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly FirstDayCoverEditModel _editModel;

        public Command(FirstDayCoverEditModel editModel)
        {
            _editModel = editModel;
        }

        public DateTime? Date 
            => _editModel.Date;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int SizeId 
            => _editModel.SizeId;

        public int[] SportIds 
            => _editModel.SportIds.ToArray();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();
    }
}
