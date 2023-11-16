namespace Memorabilia.Application.Features.Memorabilia.Bammer;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveBammer
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBammer(command.BammerTypeId,
                                  command.BrandId,
                                  command.InPackage,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SportId,
                                  command.TeamIds,
                                  command.Year);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(BammerEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int? BammerTypeId
            => editModel.BammerTypeId
                        .ToNullableInt();

        public int BrandId 
            => editModel.BrandId;

        public bool InPackage 
            => editModel.InPackage;

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People
                        .ActiveIds();

        public int? SportId 
            => editModel.SportId
                        .ToNullableInt();

        public int[] TeamIds 
            => editModel.Teams
                        .ActiveIds();

        public int? Year 
            => editModel.Year;
    }
}
