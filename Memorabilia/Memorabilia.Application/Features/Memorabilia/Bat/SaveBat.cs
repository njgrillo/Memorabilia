namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class SaveBat
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

            memorabilia.SetBat(command.BatTypeId,
                               command.BrandId,
                               command.ColorId,
                               command.GameDate,
                               command.GameStyleTypeId,
                               command.Length,
                               command.PersonId,
                               command.SizeId,
                               command.SportId,
                               command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly BatEditModel _editModel;

        public Command(BatEditModel editModel)
        {
            _editModel = editModel;
        }

        public int? BatTypeId 
            => _editModel.BatTypeId.ToNullableInt();

        public int BrandId 
            => _editModel.BrandId;

        public int? ColorId 
            => _editModel.ColorId.ToNullableInt();

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId 
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int? Length 
            => _editModel.Length > 0 
            ? _editModel.Length 
            : null;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int? PersonId 
            => _editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => _editModel.SizeId;

        public int SportId 
            => Constant.Sport.Baseball.Id;

        public int? TeamId 
            => _editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
