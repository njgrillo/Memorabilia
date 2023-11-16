namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class SaveFigure
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetFigure(command.BrandId,
                                  command.FigureSpecialtyTypeId,
                                  command.FigureTypeId,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.TeamIds,
                                  command.Year);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(FigureEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public int? FigureSpecialtyTypeId 
            => editModel.FigureSpecialtyTypeId.ToNullableInt();

        public int? FigureTypeId 
            => editModel.FigureTypeId.ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;

        public int[] SportIds 
            => editModel.SportIds.ToArray();

        public int[] TeamIds
            => editModel.Teams.ActiveIds();

        public int? Year
            => editModel.Year;
    }
}
