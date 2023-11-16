namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public class SaveHelmet
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetHelmet(command.BrandId,
                                  command.GameDate,
                                  command.GameStyleTypeId,
                                  command.HelmetFinishId,
                                  command.HelmetQualityTypeId,
                                  command.HelmetTypeId,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.Throwback,
                                  command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(HelmetEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int? HelmetFinishId 
            => editModel.HelmetFinishId.ToNullableInt();

        public int? HelmetQualityTypeId 
            => editModel.HelmetQualityTypeId.ToNullableInt();

        public int? HelmetTypeId 
            => editModel.HelmetTypeId.ToNullableInt();

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

        public bool Throwback 
            => editModel.Throwback;
    }
}
