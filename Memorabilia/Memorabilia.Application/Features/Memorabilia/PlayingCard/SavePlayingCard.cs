namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class SavePlayingCard 
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

            memorabilia.SetPlayingCard(command.PersonId,
                                       command.SizeId,
                                       command.SportId,
                                       command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PlayingCardEditModel _editModel;

        public Command(PlayingCardEditModel editModel)
        {
            _editModel = editModel;
        }

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
    }
}
