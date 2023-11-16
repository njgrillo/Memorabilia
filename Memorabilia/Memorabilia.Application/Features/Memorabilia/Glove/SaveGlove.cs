namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class SaveGlove
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetGlove(command.BrandId,
                                 command.GameDate,
                                 command.GameStyleTypeId,
                                 command.GloveTypeId,
                                 command.LevelTypeId,
                                 command.PersonIds,
                                 command.SizeId,
                                 command.SportId,
                                 command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(GloveEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int? GloveTypeId 
            => editModel.GloveTypeId.ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;

        public int? SportId 
            => editModel.SportId.ToNullableInt();

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
