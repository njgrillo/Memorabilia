namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class SavePinFlag
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

            memorabilia.SetPinFlag(command.GameDate, 
                                   command.GameStyleTypeId, 
                                   command.PersonId, 
                                   command.SportId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PinFlagEditModel _editModel;

        public Command(PinFlagEditModel editModel)
        {
            _editModel = editModel;
        }

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId 
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int? PersonId 
            => _editModel.Person?.Id.ToNullableInt() ?? null;

        public int SportId 
            => Constant.Sport.Golf.Id;
    }
}
