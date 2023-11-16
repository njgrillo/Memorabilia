namespace Memorabilia.Application.Features.Memorabilia.Jersey;

public class SaveJersey
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetJersey(command.BrandId,
                                  command.GameDate,
                                  command.GameStyleTypeId,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.QualityTypeId,
                                  command.SizeId,
                                  command.SportId,
                                  command.StyleTypeId,
                                  command.TeamIds,
                                  command.TypeId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(JerseyEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int QualityTypeId 
            => editModel.JerseyQualityTypeId;

        public int SizeId 
            => editModel.SizeId;

        public int? SportId 
            => editModel.SportId.ToNullableInt();

        public int StyleTypeId 
            => editModel.JerseyStyleTypeId;

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();

        public int TypeId 
            => editModel.JerseyTypeId;
    }
}
