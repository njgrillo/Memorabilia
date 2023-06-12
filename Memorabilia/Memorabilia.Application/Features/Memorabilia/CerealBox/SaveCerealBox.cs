namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class SaveCerealBox
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

            memorabilia.SetCerealBox(command.BrandId,
                                     command.CerealTypeId,
                                     command.LevelTypeId,
                                     command.PersonIds,
                                     command.SportIds,
                                     command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly CerealBoxEditModel _editModel;

        public Command(CerealBoxEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public int? CerealTypeId 
            => _editModel.CerealTypeId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int[] SportIds 
            => _editModel.SportIds.ToArray();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();
    }
}
