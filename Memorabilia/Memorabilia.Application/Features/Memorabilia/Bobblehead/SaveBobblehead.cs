namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class SaveBobblehead
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

            memorabilia.SetBobblehead(command.BrandId,
                                      command.HasBox,
                                      command.LevelTypeId,
                                      command.PersonId,
                                      command.SizeId,
                                      command.SportId,
                                      command.TeamId,
                                      command.Year);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly BobbleheadEditModel _editModel;

        public Command(BobbleheadEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public bool HasBox 
            => _editModel.HasBox;

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int? PersonId
            => _editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => _editModel.SizeId;

        public int? SportId 
            => _editModel.SportId.ToNullableInt();

        public int? TeamId 
            => _editModel.Team?.Id.ToNullableInt() ?? null;

        public int? Year 
            => _editModel.Year;
    }
}
