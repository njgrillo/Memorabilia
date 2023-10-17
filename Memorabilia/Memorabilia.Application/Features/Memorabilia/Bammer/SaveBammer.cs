namespace Memorabilia.Application.Features.Memorabilia.Bammer;

[AuthorizeByPermission(Enum.Permission.Memorabilia)]
public class SaveBammer
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

            memorabilia.SetBammer(command.BammerTypeId,
                                  command.BrandId,
                                  command.InPackage,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SportId,
                                  command.TeamIds,
                                  command.Year);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly BammerEditModel _editModel;

        public Command(BammerEditModel editModel)
        {
            _editModel = editModel;
        }

        public int? BammerTypeId
            => _editModel.BammerTypeId.ToNullableInt();

        public int BrandId 
            => _editModel.BrandId;

        public bool InPackage 
            => _editModel.InPackage;

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int? SportId 
            => _editModel.SportId.ToNullableInt();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();

        public int? Year 
            => _editModel.Year;
    }
}
