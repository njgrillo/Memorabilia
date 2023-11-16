namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class SaveBobblehead
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBobblehead(command.BrandId,
                                      command.HasBox,
                                      command.LevelTypeId,
                                      command.PersonId,
                                      command.SizeId,
                                      command.SportId,
                                      command.TeamId,
                                      command.Year);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(BobbleheadEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public bool HasBox 
            => editModel.HasBox;

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId
            => editModel.Person?
                        .Id
                        .ToNullableInt() ?? null;

        public int SizeId 
            => editModel.SizeId;

        public int? SportId 
            => editModel.SportId
                        .ToNullableInt();

        public int? TeamId 
            => editModel.Team?
                        .Id
                        .ToNullableInt() ?? null;

        public int? Year 
            => editModel.Year;
    }
}
