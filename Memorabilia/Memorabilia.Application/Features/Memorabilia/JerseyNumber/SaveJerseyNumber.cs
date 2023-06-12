namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class SaveJerseyNumber
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

            memorabilia.SetJerseyNumber(command.Number,
                                        command.PersonId, 
                                        command.SportId, 
                                        command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly JerseyNumberEditModel _editModel;

        public Command(JerseyNumberEditModel editModel)
        {
            _editModel = editModel;
        }

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int? Number 
            => _editModel.Number;

        public int? PersonId 
            => _editModel.Person?.Id.ToNullableInt() ?? null;

        public int? SportId 
            => _editModel.SportId.ToNullableInt();

        public int? TeamId 
            => _editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
