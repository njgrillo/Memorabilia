namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class SaveFigure
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

            memorabilia.SetFigure(command.BrandId,
                                  command.FigureSpecialtyTypeId,
                                  command.FigureTypeId,
                                  command.LevelTypeId,
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
        private readonly FigureEditModel _editModel;

        public Command(FigureEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public int? FigureSpecialtyTypeId 
            => _editModel.FigureSpecialtyTypeId.ToNullableInt();

        public int? FigureTypeId 
            => _editModel.FigureTypeId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

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

        public int? Year
            => _editModel.Year;
    }
}
