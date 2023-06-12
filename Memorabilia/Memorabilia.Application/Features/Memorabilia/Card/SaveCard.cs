namespace Memorabilia.Application.Features.Memorabilia.Card;

public class SaveCard
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

            memorabilia.SetCard(command.BrandId,
                                command.Custom,
                                command.LevelTypeId,
                                command.Licensed,
                                command.OrientationId,
                                command.PersonIds,
                                command.SizeId,
                                command.SportIds,
                                command.TeamIds,
                                command.Year);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly CardEditModel _editModel;

        public Command(CardEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public bool Custom 
            => _editModel.Custom;

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public bool Licensed 
            => _editModel.Licensed;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int OrientationId 
            => _editModel.OrientationId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int SizeId 
            => _editModel.SizeId;

        public int[] SportIds 
            => _editModel.SportIds
                         .ToArray();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();

        public int? Year 
            => _editModel.Year;
    }
}
