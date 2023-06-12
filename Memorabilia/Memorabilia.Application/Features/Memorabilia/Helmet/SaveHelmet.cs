namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public class SaveHelmet
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

            memorabilia.SetHelmet(command.BrandId,
                                  command.GameDate,
                                  command.GameStyleTypeId,
                                  command.HelmetFinishId,
                                  command.HelmetQualityTypeId,
                                  command.HelmetTypeId,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.Throwback,
                                  command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly HelmetEditModel _editModel;

        public Command(HelmetEditModel editModel)
        {
            _editModel = editModel;
        }            

        public int BrandId 
            => _editModel.BrandId;

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId 
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int? HelmetFinishId 
            => _editModel.HelmetFinishId.ToNullableInt();

        public int? HelmetQualityTypeId 
            => _editModel.HelmetQualityTypeId.ToNullableInt();

        public int? HelmetTypeId 
            => _editModel.HelmetTypeId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int SizeId 
            => _editModel.SizeId;

        public int[] SportIds 
            => _editModel.SportIds.ToArray();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();

        public bool Throwback 
            => _editModel.Throwback;
    }
}
