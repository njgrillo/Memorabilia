namespace Memorabilia.Application.Features.Memorabilia.HeadBand;

public class SaveHeadBand
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetHeadBand(command.BrandId,
                                    command.GameDate,
                                    command.GameStyleTypeId,
                                    command.LevelTypeId,
                                    command.PersonId,
                                    command.SportId,
                                    command.TeamId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(HeadBandEditModel editModel) 
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

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int? SportId 
            => editModel.SportId.ToNullableInt();

        public int? TeamId 
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
